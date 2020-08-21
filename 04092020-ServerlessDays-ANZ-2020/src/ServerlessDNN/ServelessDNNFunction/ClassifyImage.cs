using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Vision;
using Newtonsoft.Json;
using ServelessDNNFunction.DataModels;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace ServelessDNNFunction
{
    public static class ClassifyImage
    {
        private static object _predictionEngineLock = new object();

        [FunctionName("ClassifyImage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string inputFileName = "inputimage.jpg";
            string tempPath = string.Empty;

            try
            {
                tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                string imagePath = Path.Join(tempPath, inputFileName);

                var inputStream = req.Body;

                // STEP-1: Save image to temp path
                if (Directory.Exists(tempPath) == false)
                {
                    Directory.CreateDirectory(tempPath);
                }
                await using (FileStream outputFileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await inputStream.CopyToAsync(outputFileStream);
                }
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                throw;
            }

            // STEP-2: Load model
            var modelStream = ReadModelFromBlob(log);

            var mlContext = new MLContext(seed: 1);
            var trainedModel = mlContext.Model.Load(modelStream, out var modelInputSchema);

            // STEP-3: Load Data
            var testImages = ImageData.ReadFromFolder(tempPath, false);
            IDataView testData = mlContext.Data.LoadFromEnumerable(testImages);

            // STEP-4: Preprocess data
            var testPreprocessingPipeline = CreatePreprocessingPipeline(mlContext, tempPath);
            var testDataPreprocessed = testPreprocessingPipeline.Fit(testData).Transform(testData);
            IDataView testPredictionData = trainedModel.Transform(testDataPreprocessed);

            // STEP-5: Create PredictionEngine and perform prediction
            PredictionEngine<ModelInput, ModelOutput> predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);
            ModelInput input = mlContext.Data.CreateEnumerable<ModelInput>(testPredictionData, reuseRowObject: true).FirstOrDefault();

            ModelOutput predictedOutput = null;
            try
            {
                log.LogInformation("Before Prediction");
                predictedOutput = predictionEngine.Predict(input);
                log.LogInformation("After Prediction");
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                return new OkObjectResult($"An exception occured\n{e.Message}");
            }

            string imageName = Path.GetFileName(predictedOutput.ImagePath);
            string logMessage =
                $"Image: {imageName} | Actual Value: {predictedOutput.Label} | Predicted Value: {predictedOutput.PredictedLabel}";
            log.LogInformation($"{logMessage}");

            var responseMessage = $"Predicted : {predictedOutput.PredictedLabel}";
            return new OkObjectResult(responseMessage);
        }

        private static Stream ReadModelFromBlob(ILogger log)
        {
            var containerName = Environment.GetEnvironmentVariable("CONTAINER_NAME");
            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var blobFile = Environment.GetEnvironmentVariable("BLOB_FILE");

            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
                container.CreateIfNotExists(PublicAccessType.Blob);
                var blockBlob = container.GetBlockBlobClient(blobFile);
                var modelStream = new MemoryStream();

                blockBlob.DownloadTo(modelStream);
                return modelStream;
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                throw;
            }
            

            return null;
        }

        private static EstimatorChain<ImageLoadingTransformer> CreatePreprocessingPipeline(MLContext mlContext, string dataPath)
        {
            var preProcessingPipeline = mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "Label",
                    outputColumnName: "LabelAsKey")
                .Append(mlContext.Transforms.LoadRawImageBytes(
                    outputColumnName: "Image",
                    imageFolder: dataPath,
                    inputColumnName: "ImagePath"));
            return preProcessingPipeline;
        }
    }
}
