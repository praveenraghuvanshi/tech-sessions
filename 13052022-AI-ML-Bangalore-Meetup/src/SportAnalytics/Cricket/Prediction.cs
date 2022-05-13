using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;

namespace Cricket
{
    /// <summary>
    /// Performs prediction on a given dataset
    /// </summary>
    public static class Prediction
    {
        /// <summary>
        /// Executes prediction on a given dataset file
        /// </summary>
        /// <param name="datasetFile">Dataset file</param>
        public static void Execute(string datasetFile)
        {
            // Load the dataset
            var mlContext = new MLContext(seed: 1);
            IDataView data = mlContext.Data.LoadFromTextFile<Match>(
                path: datasetFile,
                hasHeader: true,
                separatorChar: ',');

            // Split dataset
            var trainTestData = mlContext.Data.TrainTestSplit(data, 0.2); // Training/Test : 80/20

            // Transform
            Console.WriteLine("Transform...");
            var dataProcessPipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(Match.TotalScore))

                .Append(mlContext.Transforms.Categorical.OneHotEncoding("VenueEncoded", nameof(Match.Venue)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("BattingTeamEncoded", nameof(Match.BattingTeam)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("BowlingTeamEncoded", nameof(Match.BowlingTeam)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("StrikerEncoded", nameof(Match.Striker)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("NonStrikerEncoded", nameof(Match.NonStriker)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("BowlerEncoded", nameof(Match.Bowler)))

                .Append(mlContext.Transforms.Concatenate("Features",
                    "VenueEncoded",
                                    nameof(Match.Inning),
                                    nameof(Match.Ball),
                                    "BattingTeamEncoded",
                                    "BowlingTeamEncoded",
                                    "StrikerEncoded",
                                    "NonStrikerEncoded",
                                    "BowlerEncoded"
                ));

            // Train
            Console.WriteLine("Train...");
            var trainingPipeline = dataProcessPipeline.Append(mlContext.Regression.Trainers.FastTree(labelColumnName: "Label", featureColumnName: "Features"));
            var trainedModel = trainingPipeline.Fit(trainTestData.TrainSet);

            // Evaluate 
            Console.WriteLine("Evaluate...");
            var predictions = trainedModel.Transform(trainTestData.TestSet);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");

            // Save
            Console.WriteLine("Save...");
            var savedPath = Path.Combine(Directory.GetCurrentDirectory(), "model.zip");
            mlContext.Model.Save(trainedModel, trainTestData.TrainSet.Schema, savedPath);
            Console.WriteLine("The model is saved to {0}", savedPath);

            // Predict
            Console.WriteLine("*********** Predict...");
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Match, MatchScorePrediction>(trainedModel);
            var match = new Match
            {
                Ball = 3.4f,
                BattingTeam = "India",
                BowlingTeam = "New Zealand",
                Bowler = "CJ Anderson",
                Inning = 1,
                Striker = "V Kohli",
                NonStriker = "Yuvraj Singh",
                Venue = "Vidarbha Cricket Association Stadium_ Jamtha"
            };

            // make the prediction
            var prediction = predictionEngine.Predict(match);

            // report the results
            Console.WriteLine($"Passenger:   {match} ");
            Console.WriteLine($"Prediction:  {prediction.TotalScore} ");
            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Predicted score: {prediction.TotalScore:0.####}, actual fare: 20");
            Console.WriteLine($"**********************************************************************");
        }
    }
}
