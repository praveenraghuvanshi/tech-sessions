using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using System.IO;

namespace SentimentAnalysis
{
    class Program
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "data", "yelp_labelled.txt");
        static void Main(string[] args)
        {
            // Initialize ML Context
            MLContext mlContext = new MLContext();

            // Load : Split it into 80% training and 20% test data
            var trainTestSplit = 0.2;
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, 	hasHeader: false);
            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: trainTestSplit);

            // Transform : Converts the text column(SentimentText) into numeric type Features column using FeaturizeText
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
                        .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            // Train/Fit model
            Console.WriteLine("=============== Create and Train the Model ===============");
            var model = estimator.Fit(splitDataView.TrainSet);
            Console.WriteLine("=============== End of training ===============");
            Console.WriteLine();

            // Evaluate : Evaluate performance of the model using Test set
            Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
            IDataView predictions = model.Transform(splitDataView.TestSet);
            CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

            // Display Metrics
            Console.WriteLine();
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("=============== End of model evaluation ===============");

            // Create PredictionEngine passing above model
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);

            // Create sample text
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = "This was a very bad steak"
            };

            // Predict
            var resultPrediction = predictionFunction.Predict(sampleStatement);

            // Display Prediction
            Console.WriteLine();
            Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============");

            Console.WriteLine();
            Console.WriteLine($"Sentiment: {resultPrediction.SentimentText} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");

            Console.WriteLine("=============== End of Predictions ===============");
            Console.WriteLine();

            // Save Model
            mlContext.Model.Save(model, splitDataView.TrainSet.Schema,"model.zip");
        }
    }
}
