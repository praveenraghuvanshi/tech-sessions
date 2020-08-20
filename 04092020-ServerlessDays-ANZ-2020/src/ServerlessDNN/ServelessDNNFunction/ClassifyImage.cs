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
        [FunctionName("ClassifyImage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string inputFileName = "inputimage.jpg";
            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string imagePath = Path.Join(tempPath, inputFileName);
            var inputStream = req.Body;

            // STEP-1: Save image to temp path
            try
            {
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
            var modelStream = ReadModelFromBlob();

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
            IEnumerable<ModelOutput> predictions = mlContext.Data.CreateEnumerable<ModelOutput>(testPredictionData, reuseRowObject: true);

            var predictedValue = predictions?.FirstOrDefault().PredictedLabel;

            string responseMessage = $"Predicted: {predictedValue}";
            return new OkObjectResult(responseMessage);
        }

        private static Stream ReadModelFromBlob()
        {
            var containerName = Environment.GetEnvironmentVariable("CONTAINER_NAME");
            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var blobFile = Environment.GetEnvironmentVariable("BLOB_FILE");

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists(PublicAccessType.Blob);

            var blockBlob = container.GetBlockBlobClient(blobFile);
            var modelStream = new MemoryStream();
            blockBlob.DownloadTo(modelStream);

            return modelStream;
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
