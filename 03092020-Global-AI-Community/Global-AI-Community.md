<img src=".\assets\global-ai-community-logo.png" alt="Global AI Talks" style="zoom:80%;margin:auto;" />
<img src=".\assets\praveen.png" alt="Introduction" style="zoom:40%;margin:auto;">

# Machine Learning using C# on Jupyter Notebook!

# Introduction

- Cloud Architect @ Harman, A Samsung Company    
- Domain: Professional Audio, Video and Control
- Area of Expertise: Cloud, Distributed computing
- Area of Interest: AI/ML, Cloud and IoT
- Location: Bangalore
- Member: .Net Foundation

# Agenda

- Jupyter Notebook
- .Net on Juypter Notebook
- Prerequisites & Installation
- Machine Learning – ML.Net
- Demo – Sentiment Analysis

# Jupyter Notebook

*A notebook = Code + Output (Visualizations/text/equations/media)*
- Open source web application maintained by [Project Jupyter](https://jupyter.org/)
- Live code
- Easy to share notebooks
- Stores results from previous execution
- Mainly used by Data scientists 

# Jupyter Notebook

<img src=".\assets\jupyter-notebook-features.png" alt="Jupyter Notebook Features" style="zoom:40%;margin:auto;">

# .Net on Jupyter Notebook


```C#
public class Employee
{    
    public Employee(string firstName, string lastName)
    {
        FirstName = firstName; LastName = lastName;
    }    
    public string FirstName { get; set; }    
    public string LastName { get; set; }    
    public string FullName => $"{FirstName}_{LastName}";
}
var developer = new Employee("Praveen", "Raghuvanshi");
display(developer.FullName);
```


    Praveen_Raghuvanshi


# Prerequisites and Installation

- Jupyter (Easiest way is to install Anaconda)
- Latest [.Net core](https://dotnet.microsoft.com/download/dotnet-core)  
- [dotnet interactive](https://github.com/dotnet/interactive) : [Installation](https://github.com/dotnet/interactive/blob/main/docs/NotebooksLocalExperience.md)
- Enable the .NET kernel for Jupyter

# ML.Net

*ML framework from Microsoft for developing Custom AI/ML applications. Originated in 2002 as part of Microsoft Research project*

<img src=".\assets\ml-dotnet-vs-cognitive.png" alt="ML.Net" style="zoom:80%;margin:auto;">


<img src=".\assets\ml-dotnet.png" alt="ML.Net" style="zoom:120%;margin:auto;">

# Proven at scale, Enterprise ready

<img src=".\assets\ml-dotnet-use-case.png" alt="ML.Net" style="zoom:80%;margin:auto;">

# Possibilities

<img src=".\assets\ml-dotnet-possiblities.png" alt="ML.Net" style="zoom:80%;margin:auto;">

# Demo - Sentiment Analysis

- Positive(+ve) , Negative(-ve)
- Sentiment(Label) and Text(Features)
- Train model using ML.Net
- ML Pipeline : Load -> Transform -> Train -> Evaluate -> Predict

# Dataset - Yelp Reviews

<img src=".\assets\sentiment-dataset.png" alt="Dataset" style="zoom:80%;margin:auto;">

### 1. Define Application wide Items

#### Nuget Packages
- Microsoft.ML


```C#
// ML.NET Nuget packages installation
#r "nuget:Microsoft.ML"
```


Installed package Microsoft.ML version 1.5.1


#### Namespaces


```C#
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using System;
using System.IO;
```

### 2. Load data

#### Set the dataset path


```C#
var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
display(dataPath)
```


    D:\Praveen\sourcecontrol\github\praveenraghuvanshi\tech-sessions\03092020-Global-AI-Community\Data\yelp_labelled.txt


#### Define Schema(classes) for input data and predictions


```C#
/// Input
public class SentimentData
{
    [LoadColumn(0)]
    public string SentimentText;

    [LoadColumn(1), ColumnName("Label")]
    public bool Sentiment;
}

/// Prediction
public class SentimentPrediction : SentimentData
{

    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}
```


```C#
// Initialize ML Context
MLContext mlContext = new MLContext();
```


```C#
// Load : Split it into 80% training and 20% test data
public TrainTestData LoadData(MLContext mlContext)
{
    IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(dataPath, hasHeader: false);
    TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
    return splitDataView;
}
```


```C#
TrainTestData splitDataView = LoadData(mlContext);
```

### 3. Transform data and choose algorithm


```C#
// Transform : Converts the text column(SentimentText) into numeric type Features column using FeaturizeText
var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
                        .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

```

### 4. Train Model


```C#
// Train/Fit model
display("=============== Create and Train the Model ===============");
var model = estimator.Fit(splitDataView.TrainSet);
display("=============== End of training ===============");
```


    =============== Create and Train the Model ===============



    =============== End of training ===============


### 5. Evaluate Model


```C#
// Evaluate : Evaluate performance of the model using Test set
Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
IDataView predictions = model.Transform(splitDataView.TestSet);
CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");
```

    =============== Evaluating Model accuracy with Test data===============



```C#
// Display Metrics
display("Model quality metrics evaluation");
display("--------------------------------");
display($"Accuracy: {metrics.Accuracy:P2}");
display($"Auc: {metrics.AreaUnderRocCurve:P2}");
display($"F1Score: {metrics.F1Score:P2}");
display("=============== End of model evaluation ===============");
```


    Model quality metrics evaluation



    --------------------------------



    Accuracy: 83.96%



    Auc: 90.05%



    F1Score: 84.54%



    =============== End of model evaluation ===============


### 6. Prediction


```C#
// Create PredictionEngine passing above model
var predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
```


```C#
// Create sample text
SentimentData sampleStatement = new SentimentData
{
    SentimentText = "This was a very bad steak"
};

// Predict
var resultPrediction = predictionFunction.Predict(sampleStatement);
```


```C#
// Display Prediction
display("=============== Prediction Test of model with a single sample and test dataset ===============");
display($"Sentiment: {resultPrediction.SentimentText} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");
display("=============== End of Predictions ===============");
```


    =============== Prediction Test of model with a single sample and test dataset ===============



    Sentiment: This was a very bad steak | Prediction: Negative | Probability: 0.031075107 



    =============== End of Predictions ===============


### 7. Save Model


```C#
// Save Model
mlContext.Model.Save(model, splitDataView.TrainSet.Schema,"SentimentAnalysisModel.zip");
```

# Resources

- Github: 

# References

- [How to Use Jupyter Notebook in 2020: A Beginner’s Tutorial](dataquest.io/blog/jupyter-notebook-tutorial/)
- [.Net interactive](https://github.com/dotnet/interactive)
- [Using ML.NET in Jupyter notebooks](https://devblogs.microsoft.com/cesardelatorre/using-ml-net-in-jupyter-notebooks/)

# Thank you

**Contact**

Twitter : @praveenraghuvan\
LinkedIn : https://in.linkedin.com/in/praveenraghuvanshi \
Github : https://github.com/praveenraghuvanshi \
dev.to : https://dev.to/praveenraghuvanshi

I am running an unofficial **telegram** group for ML.Net enthusiasts, please feel free to join it at https://t.me/joinchat/IifUJQ_PuYT757Turx-nLg
