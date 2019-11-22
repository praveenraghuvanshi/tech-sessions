# Binary Classification - Sentiment Analysis

We are going to build a system to predict the sentiment of a review given on Yelp website. As sentiment is going to be positive or negative, it's a binary classification problem. We'll be creating a .Net core console application to predict the sentiment.

Dataset: [UCI Sentiment Labeled Sentences dataset ZIP file](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment labelled sentences.zip)

Reference :  [Microsoft](https://docs.microsoft.com/en-us/dotnet/machine-learning/tutorials/sentiment-analysis#prepare-your-data)

### Steps

##### Step 1: Create .Net core console application

- Open Visual Studio Code and Create a .Net core console application by executing below command(s) in terminal

  - ```
    dotnet new sln --name SentimentAnalysisDemo
    
    dotnet new console -o SentimentAnalysis
    
    dotnet sln SentimentAnalysisDemo.sln add .\SentimentAnalysis\SentimentAnalysis.csproj
    ```

##### Step 2: Download and unzip dataset

- Create directory 'data' under generate 'SentimentAnalysis' directory at the project level
- Download [Dataset](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip), unzip and copy 'yelp_labelled.txt' to data folder

- Open 'yelp_labelled.txt', data will be as below

- - | Text                                       | Sentiment |
    | ------------------------------------------ | --------- |
    | Wow... Loved this  place.                  | 1         |
    | The fries were  great too.                 | 1         |
    | Not tasty and the  texture was just nasty. | 0         |
    | A great touch.                             | 1         |
    | Waitress was a  little slow in service.    | 0         |

    

- Sentiment has a value of 1 or 0. 1 means positive and 0 means negative

- Open 'SentimentAnalysis.csproj' in VSCode and copy below text just before </Project> tag. 'CopyToOutputDirectory' is important as it determines whether to copy yelp_labelled.csv to the application executing directory. 'PreserveNewest' allows copying of file in case there a new version of it. 

  ```
  <ItemGroup>
  	<Content Include="data/yelp_labelled.txt"> 
      	<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      </Content>
  </ItemGroup>
  ```

  

##### Step 3:  Prepare data

- Install packages : Go to 'SentimentAnalysis' directory and execute below commands

  ```c#
  dotnet add package Microsoft.ML
  ```

- Create two class ' SentimentData' and ' SentimentPrediction' in file SentimentData.cs. Add below code in respective classes

  ```c#
  using Microsoft.ML.Data;
  
  namespace SentimentAnalysis
  {
      public class SentimentData
      {
          [LoadColumn(0)]
          public string SentimentText;
  
          [LoadColumn(1), ColumnName("Label")]
          public bool Sentiment;
      }
  
      public class SentimentPrediction : SentimentData
      {
  
          [ColumnName("PredictedLabel")]
          public bool Prediction { get; set; }
  
          public float Probability { get; set; }
  
          public float Score { get; set; }
      }
  }
  ```

  

- LoadColumn : Determines the order of fields in dataset.

- ColumnName: Designated name of the column/custom name

- Prediction: Its the value predicted by model when a new value is given

- Score: Its the raw score calculated by model

- Probability:  the score calibrated to the likelihood of the text having positive sentiment. 

##### Step 4: Load dataset

- Open Program.cs

- IDataview : Data in ML.Net is represented in IDataView

- MLContext: Its the starting point for all ML.Net operations. It's similar to DBContext in Entity framework

- Add file path to a variable

  ```c#
  using System.IO;
  
  static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
  ```

  

- Load : Split it into 80% training and 20% test data

  ```c#
  // Initialize ML Context
  MLContext mlContext = new MLContext();
  
  // Load : Split it into 80% training and 20% test data
  var trainTestSplit = 0.2;
  IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, 			hasHeader: false);
  TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 	trainTestSplit);
  ```

  

##### Step 5: Transform

- FeaturizeText - It converts the text column(SentimentText) into numeric type Features column

  ```c#
  // Transform : Converts the text column(SentimentText) into numeric type Features column using FeaturizeText
  var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", 	inputColumnName: nameof(SentimentData.SentimentText));
  ```

##### Step 6: Build and Train

- Add a learning algorithm

  ```c#
  .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
  ```

   The [SdcaLogisticRegressionBinaryTrainer](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.trainers.sdcalogisticregressionbinarytrainer) is the classification training algorithm 

- Train/Fit model : We pass only the training data(TrainSet)

  ```c#
  Console.WriteLine("=============== Create and Train the Model ===============");
  var model = estimator.Fit(splitDataView.TrainSet);
  Console.WriteLine("=============== End of training ===============");
  Console.WriteLine();
  ```

  

##### Step 7: Evaluate

- Evaluate performance of the model using Test set

  ```c#
  // Evaluate : Evaluate performance of the model using Test set
  Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
  IDataView predictions = model.Transform(splitDataView.TestSet);
  CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");
  ```

  

##### Step 8: Display Metrics

```c#
Console.WriteLine();
Console.WriteLine("Model quality metrics evaluation");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
Console.WriteLine("=============== End of model evaluation ===============");
```

##### Step 9: Run program

- Execute dotnet run on terminal
- Output

```html
Model quality metrics evaluation
--------------------------------
Accuracy: 83.96%
Auc: 90.51%
F1Score: 84.04%

=============== End of model evaluation ===============
```



##### Step 10: Predict

- Prediction allows validating model on an unseen/new data

- PredictionEngine is a convenience API, which allows prediction on single instance of data.

- PredictionEngine is not thread-safe

- For improved performance and thread-safety use PredictionEnginePool service which creates a Pool of PredictionEngine objects for use throughout the application.

-  Add a comment to test the trained model's prediction and pass it to Predict function.

  ```c#
  // Create PredictionEngine passing above model
  PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
  
  // Create sample text
  SentimentData sampleStatement = new SentimentData
  {
      SentimentText = "This was a very bad steak"
  };
  
  // Predict
  var resultPrediction = predictionFunction.Predict(sampleStatement);
  ```

  

- Display and Run program

  ```c#
  Console.WriteLine();
  Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============");
  
  Console.WriteLine();
  Console.WriteLine($"Sentiment: {resultPrediction.SentimentText} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");
  
  Console.WriteLine("=============== End of Predictions ===============");
  Console.WriteLine();
  ```



##### Step 11: Save Model

- Save a model to be used in other applications such as console, Winform, WPF, Asp.Net

- A model.zip file will be generated in the current directory.

  ```c#
  mlContext.Model.Save(model, splitDataView.TrainSet.Schema,"model.zip");
  ```

  