using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Vision;
using ServerlessDNN.DataModels;

namespace ServerlessDNN
{
    class Program
    {
        private static string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
        private static string assetsRelativePath = Path.Combine(projectDirectory, "assets");
        private static string imagesRelativePath = Path.Combine(assetsRelativePath, "images");
        private static string trainRelativePath = Path.Combine(imagesRelativePath, "train");
        private static string testRelativePath = Path.Combine(imagesRelativePath, "test");
        private static string valRelativePath = Path.Combine(imagesRelativePath, "val");

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Serverless Deep Neural Network example!");

            #region Build

            // Load train data 
            var trainImages = ImageData.ReadFromFolder(trainRelativePath);

            // Initialize ML Pipeline
            var mlContext = new MLContext(seed: 1);
            IDataView trainData = mlContext.Data.LoadFromEnumerable(trainImages);
            var shuffledData = mlContext.Data.ShuffleRows(trainData);

            // Preprocess data
            var preprocessingPipeline = mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "Label",
                    outputColumnName: "LabelAsKey")
                .Append(mlContext.Transforms.LoadRawImageBytes(
                    outputColumnName: "Image",
                    imageFolder: trainRelativePath,
                    inputColumnName: "ImagePath"));

            var preProcessedData = preprocessingPipeline.Fit(shuffledData).Transform(shuffledData);

            #endregion

            #region Train

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

            #endregion

            #region Evaluate

            #endregion

            #region Predict

            #endregion
        }
    }
}
