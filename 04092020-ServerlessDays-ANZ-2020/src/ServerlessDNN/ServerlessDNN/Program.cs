using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Vision;
using ServerlessDNN.DataModels;

namespace ServerlessDNN
{
    class Program
    {
        private static string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../")); // x64
        private static string assetsRelativePath = Path.Combine(projectDirectory, "assets");
        private static string imagesRelativePath = Path.Combine(assetsRelativePath, "images");
        private static string trainRelativePath = Path.Combine(imagesRelativePath, "train");
        private static string testRelativePath = Path.Combine(imagesRelativePath, "test");
        private static string valRelativePath = Path.Combine(imagesRelativePath, "val");
        private static string modelOutputPath = Path.Combine(assetsRelativePath, "model.zip");

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Serverless Deep Neural Network example!!!");

            #region Build

            Console.WriteLine("\n****** Build Model - Started *******");

            // Load train data 
            var trainImages = ImageData.ReadFromFolder(trainRelativePath, true);

            // Initialize ML Pipeline
            var mlContext = new MLContext(seed: 1);
            IDataView trainData = mlContext.Data.LoadFromEnumerable(trainImages);
            var shuffledData = mlContext.Data.ShuffleRows(trainData);

            // Preprocess data
            var preprocessingPipeline = CreatePreprocessingPipeline(mlContext, trainRelativePath);
            var preProcessedData = preprocessingPipeline.Fit(shuffledData).Transform(shuffledData);

            Console.WriteLine("\n****** Build Model - End *******");
            #endregion

            #region Train

            Console.WriteLine("\n****** Train Model - Started *******");

            var classifierOptions = new ImageClassificationTrainer.Options()
            {
                FeatureColumnName = "Image",
                LabelColumnName = "LabelAsKey",
                Arch = ImageClassificationTrainer.Architecture.ResnetV2101,
                MetricsCallback = (metrics) => Console.WriteLine(metrics)
            };

            var trainingPipeline = mlContext.MulticlassClassification.Trainers.ImageClassification(classifierOptions)
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            ITransformer trainedModel = trainingPipeline.Fit(preProcessedData);

            Console.WriteLine("\n****** Train Model - End *******");

            #endregion

            #region Evaluate

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n****** Evaluate Model - Started *******");

            // Load validation data
            var valImages = ImageData.ReadFromFolder(valRelativePath, true);
            IDataView valData = mlContext.Data.LoadFromEnumerable(valImages);
            var valShuffledData = mlContext.Data.ShuffleRows(valData);
            
            // Preprocess data
            var valPreprocessingPipeline = CreatePreprocessingPipeline(mlContext, valRelativePath);
            var valDataPreprocessed = valPreprocessingPipeline.Fit(valShuffledData).Transform(valShuffledData);
            IDataView valPredictionData = trainedModel.Transform(valDataPreprocessed);

            // Evaluate to generate metrics
            MulticlassClassificationMetrics metrics =
                mlContext.MulticlassClassification.Evaluate(valPredictionData,
                    labelColumnName: "LabelAsKey",
                    predictedLabelColumnName: "PredictedLabel");

            // Print Metrics
            PrintMetrics(metrics);

            Console.ResetColor();
            Console.WriteLine("\n****** Evaluate Model - End *******");

            #endregion

            #region Predict

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n****** Prediction - Started *******");

            // Load Data
            var testImages = ImageData.ReadFromFolder(testRelativePath, true);
            IDataView testData = mlContext.Data.LoadFromEnumerable(testImages);
            var testShuffledData = mlContext.Data.ShuffleRows(testData);

            // Preprocess data
            var testPreprocessingPipeline = CreatePreprocessingPipeline(mlContext, testRelativePath);
            var testDataPreprocessed = testPreprocessingPipeline.Fit(testShuffledData).Transform(testShuffledData);
            IDataView testPredictionData = trainedModel.Transform(testDataPreprocessed);

            // Create PredictionEngine and perform prediction
            PredictionEngine<ModelInput, ModelOutput> predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);
            IEnumerable<ModelOutput> predictions = mlContext.Data.CreateEnumerable<ModelOutput>(testPredictionData, reuseRowObject: true);
            
            // Display Result
            Console.WriteLine("\nClassifying multiple images");
            foreach (var prediction in predictions)
            {
                string imageName = Path.GetFileName(prediction.ImagePath);
                Console.WriteLine($"Image: {imageName} | Actual Value: {prediction.Label} | Predicted Value: {prediction.PredictedLabel}");
            }

            Console.ResetColor();
            Console.WriteLine("\n****** Prediction - End *******");

            #endregion

            #region Save Model

            Console.WriteLine("\n****** Save Model - Start *******");

            mlContext.Model.Save(
                model: trainedModel,
                inputSchema: null,
                filePath: modelOutputPath);

            Console.WriteLine($"\nModel saved to : {modelOutputPath}");
            #endregion
        }

        private static void PrintMetrics(MulticlassClassificationMetrics metrics)
        {
            Console.WriteLine("\n............ Metrics ...........");
            Console.WriteLine($"Macro Accuracy: {(metrics.MacroAccuracy * 100):0.##}%");
            Console.WriteLine($"Micro Accuracy: {(metrics.MicroAccuracy * 100):0.##}%");
            Console.WriteLine($"LogLoss is: {metrics.LogLoss:0.##}, value close to 0 is better");
            Console.WriteLine(
                $"PerClassLogLoss is: {String.Join(" , ", metrics.PerClassLogLoss.Select(c => c.ToString("0.##")))}, value close to 0 is better");
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
