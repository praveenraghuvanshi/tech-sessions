using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Newtonsoft.Json;

namespace CricketScorePredictionFunctionApp
{
    public static class PredictScoreFn
    {
        private static string MODEL_FILE = "model.zip";
        private static MLContext _mlContext;

        [FunctionName("PredictScore")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext executionContext)
        {
            log.LogInformation("Predict Score triggered...");
            log.LogInformation("**************************");
            log.LogInformation($"CodeBase: {Assembly.GetExecutingAssembly().CodeBase}");
            log.LogInformation($"Location: {Assembly.GetExecutingAssembly().Location}");
            log.LogInformation($"Environment Current Directory: {Environment.CurrentDirectory}");
            log.LogInformation($"Base Directory: {AppDomain.CurrentDomain.BaseDirectory}");
            log.LogInformation($"Function App Directory: {executionContext?.FunctionAppDirectory}");
            log.LogInformation("**************************");

            var modelPath = Path.Combine(executionContext.FunctionAppDirectory, "Models", MODEL_FILE);
            if (!File.Exists(modelPath))
            {
                log.LogError($"The File does not exist at Function App Directory path : {modelPath}");
            }

            var currentDirectoryPath = Path.Combine(Assembly.GetExecutingAssembly().Location, "Models", MODEL_FILE);
            if (!File.Exists(currentDirectoryPath))
            {
                log.LogError($"The File does not exist at current Directory path : {currentDirectoryPath}");
            }

            var matchData = await ParseMatchData(req);
            var model = LoadModel(modelPath);
            var score = PredictScore(model, matchData);

            return new OkObjectResult($"{score:0.##}");
        }

        private static float PredictScore(ITransformer model, Match matchToBeScored)
        {
            PredictionEngine<Match, MatchScorePrediction> predictionEngine = _mlContext.Model.CreatePredictionEngine<Match, MatchScorePrediction>(model);
            var prediction = predictionEngine.Predict(matchToBeScored);
            return prediction.TotalScore;
        }

        private static ITransformer LoadModel(string modelPath)
        {
            DataViewSchema modelSchema;
            ITransformer trainedModel;

            _mlContext = new MLContext(seed: 1);
            try
            {
                trainedModel = _mlContext.Model.Load(modelPath, out modelSchema);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return trainedModel;
        }

        private static async Task<Match> ParseMatchData(HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Match matchData = null;
            try
            {
                matchData = JsonConvert.DeserializeObject<Match>(requestBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return matchData;
        }
    }
}
