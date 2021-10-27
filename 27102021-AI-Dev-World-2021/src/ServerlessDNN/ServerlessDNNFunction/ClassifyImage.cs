using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Transforms.Image;
using ServerlessDNNFunction;
using System.Drawing;
using System.Linq;

namespace ServelessDNNFunction
{
    public static class ClassifyImage
    {
        [FunctionName("ClassifyImage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            #region App Settings
            
            // Load App Settings
            var containerName = Environment.GetEnvironmentVariable("CONTAINER_NAME") ?? "serverlessdnn";
            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage") ?? "UseDevelopmentStorage=true";
            var modelName = Environment.GetEnvironmentVariable("MODEL") ?? "mobilenetv2-7.onnx";
            #endregion

            #region Load Model
            // STEP-1: Upload model to Blob storage as it might have been already done. No action required here.

            // STEP-2: Load model from Blob storage and save to temp path
            string tempPath = CreateTempDirectory(log);

            var modelStream = ReadModelFromBlob(log, connectionString, containerName, modelName);
            var savedModelPath = SaveModel(log, tempPath, modelName, modelStream);
            log.LogInformation($"Model saved to : {savedModelPath}");
            #endregion

            #region Load model into ML.Net context
            // STEP-3: Load ONNX model into ML.Net MLContext
            var modelInputName = "data";
            var modelOutputName = "mobilenetv20_output_flatten0_reshape0";

            var mlContext = new MLContext(seed: 1);

            var emptyData = new List<ModelInput>();
            var data = mlContext.Data.LoadFromEnumerable(emptyData);

            var pipeline = mlContext.Transforms.ResizeImages(resizing: ImageResizingEstimator.ResizingKind.Fill, outputColumnName: modelInputName, imageWidth: ImageSettings.Width, imageHeight: ImageSettings.Height, inputColumnName: nameof(ModelInput.ImageSource))
                .Append(mlContext.Transforms.ExtractPixels(outputColumnName: modelInputName))
                .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: savedModelPath, outputColumnName: modelOutputName, inputColumnName: modelInputName));

            #endregion

            #region Train
            var model = pipeline.Fit(data);
            #endregion

            #region Prediction
            // STEP-4: Prediction
            Bitmap testImage = (Bitmap)Image.FromStream(req.Body);

            ModelInput inputData = new ModelInput()
            {
                ImageSource = testImage
            };

            var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
            var prediction = predictionEngine.Predict(inputData);
            var maxScore = Convert.ToInt16(prediction.Score?.Max());
            #endregion

            #region Response
            // STEP-5: Return Predicted value as a response to Function API
            string responseMessage = $"Predicted: {maxScore}";
            return new OkObjectResult(responseMessage);
            #endregion
        }

        private static string CreateTempDirectory(ILogger log)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            try
            {
                if (Directory.Exists(tempPath) == false)
                {
                    Directory.CreateDirectory(tempPath);
                }
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                throw;
            }

            return tempPath;
        }

        private static Stream ReadModelFromBlob(ILogger log, string connectionString, string containerName, string modelName)
        {
            try
            {
                BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
                container.CreateIfNotExists(PublicAccessType.Blob);
                var blockBlob = container.GetBlockBlobClient(modelName);

                log.LogInformation($"Loading Model : {modelName}");

                var modelStream = new MemoryStream();
                blockBlob.DownloadTo(modelStream);
                return modelStream;
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                throw;
            }
        }

        private static string SaveModel(ILogger log, string tempPath, string modelName, Stream modelStream)
        {
            string savedModelPath = Path.Combine(tempPath, modelName);

            try
            {
                using (var fileStream = File.Create(savedModelPath))
                {
                    modelStream.Seek(0, SeekOrigin.Begin);
                    modelStream.CopyTo(fileStream);
                }
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                throw;
            }

            return savedModelPath;
        }
    }
}