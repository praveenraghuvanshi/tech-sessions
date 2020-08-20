# Serverless Deep Neural Network with Azure Functions and ML.Net

## Introduction

dfaf

## Serverless

dfa

## Azure Functions

fadsf

## Deep Neural Network

faf

## ML.Net

faf

## Application

We are going to create an application that will classify an image as a cat or dog. First we'll create a local console application and thereafter move it to Azure function(Local and Cloud). The framework used for this exercise is ML.Net and language is C#.

### Prerequisites

- IDE - [Visual Studio](https://visualstudio.microsoft.com/) / [Visual Studio Code](https://code.visualstudio.com/download)
- REST Client - [Postman](https://www.postman.com/downloads/)
- Serverless Deployment - [Azure subscription (Only for cloud deployment to Azure Function)](https://azure.microsoft.com/en-in/)

### Dataset

Dataset plays an important role in Machine learning and it's not only the count that matters, quality of image also matters. Quality such as size, lighting, blurriness etc. In order to keep things simple, I have considered few images only. As we are going use pre-trained model, we don't need much data for demonstration. This will give a pretty decent accuracy on the trained model. 

Its a good practice to divide the dataset into train, test and validation dataset. 

- **Train:** A train dataset comprise of major portion on which model is trained and features are extracted.
- **Validation:**  A validation dataset is used to evaluate the accuracy of trained model. 
- **Test:** A test dataset is used to make predictions using trained model.

<img src="D:\Praveen\sourcecontrol\github\praveenraghuvanshi\tech-sessions\04092020-ServerlessDays-ANZ-2020\assets\data-split.png" alt="Data Split" style="zoom:50%;" />

The dataset is further divided as per the classes to be predicted. In this case, its cat and dog.

Dataset folder is structured as below.

<img src=".\assets\dataset-folder-structure.png" alt="Dataset Folder Structure" style="zoom:80%;" />



Sample Images

![Sample Images](D:\Praveen\sourcecontrol\github\praveenraghuvanshi\tech-sessions\04092020-ServerlessDays-ANZ-2020\assets\sample-images.png)

### Image Classification - Console Application(C#)

Now we'll create a console application for classifying an image as a cat or dog.

Open Visual Studio and create a new C# console project and name it as 'ServerlessDNN'.

Add a directory 'assets' and copy the 'Images' directory along with images of cats and dogs.

<img src=".\assets\vs-images.png" alt="Images directory" style="zoom:80%;" />



We'll create ML pipeline of building a ML model first, train it over existing data and evaluate it on validation data. Once we are convinced with the accuracy, we'll make predictions over test data.

![ML Pipeline](.\assets\ml-pipeline.png)

1. **Build Model**

   We need to define classes for our input data and predictions 

   Create 'DataModels' directory and ImageData.cs file in the solution

   **ImageData** holds information about the images to be loaded.

   ```c#
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;
   
   namespace ServerlessDNN.DataModels
   {
       /// <summary>
       /// Manages information about the images
       /// </summary>
       public class ImageData
       {
           /// <summary>
           /// Fully qualified path of stored image
           /// </summary>
           public string ImagePath;
   
           /// <summary>
           /// It is the category the image belongs to. This is the value to predict.
           /// </summary>
           public string Label;
   
           /// <summary>
           /// Gets the collection images from the specified folder
           /// </summary>
           /// <param name="imageFolder"></param>
           /// <returns></returns>
           public static IEnumerable<ImageData> ReadFromFile(string imageFolder)
           {
               return Directory
                   .GetFiles(imageFolder)
                   .Where(filepath => Path.GetExtension(filepath) == ".jpg" || Path.GetExtension(filepath) == ".png")
                   .Select(filePath => new ImageData {ImagePath = filePath, Label = Path.GetFileName(filePath)});
           }
       }
   }
   ```

   **ModelInput** class defines the schema for input data and is defined as below

   ```c#
   using System;
   
   namespace ServerlessDNN.DataModels
   {
       /// <summary>
       /// Defines schema for the input data
       /// </summary>
       public class ModelInput
       {
           /// <summary>
           /// A byte[] representation of the image
           /// </summary>
           public byte[] Image { get; set; }
   
           /// <summary>
           /// Numerical representation of the Label
           /// </summary>
           public UInt32 LabelAsKey { get; set; }
   
           /// <summary>
           /// Fully qualified path of stored image
           /// </summary>
           public string ImagePath { get; set; }
   
           /// <summary>
           /// It is the category the image belongs to. This is the value to predict.
           /// </summary>
           public string Label { get; set; }
       }
   }
   ```

   **ModelOutput** defines schema for the output data and is defined as below

   ```c#
   using System;
   
   namespace ServerlessDNN.DataModels
   {
       /// <summary>
       /// Defines schema for the output data
       /// </summary>
       class ModelOutput
       {
           /// <summary>
           /// Fully qualified path of stored image
           /// </summary>
           public string ImagePath { get; set; }
   
           /// <summary>
           /// It is the category the image belongs to. This is the value to predict.
           /// </summary>
           public string Label { get; set; }
   
           /// <summary>
           /// The value predicted by the model
           /// </summary>
           public string PredictedLabel { get; set; }
       }
   }
   ```

   We have data models and our solution should look like as below

   ![image-20200819100452652](D:\Praveen\sourcecontrol\github\praveenraghuvanshi\tech-sessions\04092020-ServerlessDays-ANZ-2020\assets\vs-images-models.png)

   **Load data**

   Navigate to Program.cs and declare below variable to access the path of assets just above the Main method

   ```c#
   private static string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../")); private static string assetsRelativePath = Path.Combine(projectDirectory, "assets");
   ```

   I have added different regions within Main method for different stages in a ML pipeline as shown below. We'll fill each of these regions as we progress further. 

   <img src=".\assets\main-build.png" alt="Build Model" style="zoom:80%;" />

   

   In order to load the data to be used within ML pipeline, we need to create MLContext that acts as a starting point of any Machine learning application using ML.Net

   Add below nuget packages for Build Model step

   - Microsoft.ML
   - Microsoft.ML.ImageAnalytics

   Steps to build the model

   - Load data
   - Initialize MLContext and shuffle data
   - Preprocess data
     - MapValueToKey - ML models expect input to be numerical, labels/class is string and needs to be converted to numeric
     - LoadRawImageBytes - Loads image for training
   - Fit - Applied preprocessing to the data
   - Transform - Get the preprocessed data as a IDataView

   ```c#
   #region Build
   
   // Load train data 
   var images = ImageData.ReadFromFolder(trainRelativePath);
   
   // Initialize ML Pipeline
   var mlContext = new MLContext(seed: 1);
   IDataView imageData = mlContext.Data.LoadFromEnumerable(images);
   var shuffledData = mlContext.Data.ShuffleRows(imageData);
   
   // Preprocess data
   var preprocessingPipeline = mlContext.Transforms.Conversion.MapValueToKey(
   		inputColumnName: "Label",
           outputColumnName: "LabelAsKey")
           .Append(mlContext.Transforms.LoadRawImageBytes(
           outputColumnName: "Image",
           imageFolder: trainRelativePath,
           inputColumnName: "ImagePath"));
   
   #endregion
   ```

   

2. Train Model

   Now data is ready and model is ready to be trained. Training a deep neural network is the core of Machine learning task. During this task, a model processes the set of images provided and extract features such as edges, gradients, patterns and objects. These could be eyes, ears, nose etc. The model does a forward and a backward pass during and adjusts weights of the network in order to learn features better. 

   ML.Net ImageClassifierTrainer provides a set of options that could be leveraged to fine tune the model training. Some of them are explained below. In order to keep the tutorial simple, I have used a minimal set of options.

   Steps in training a model

   - Add 'Microsoft.ML.Vision' nuget reference
   - ImageClassifierTrainer options
     - FeatureColumnName: Input column name
     - LabelColumnName : Name of column to be predicted
     - Arch: Architecture to be used for training. Currently, ML.Net supports only Inception, MobileNet, Resnet.
     - MetricCallback: Gives the progress of training.
   - Create an ImageClassificationTrainer to train the model.
   - Converting encoded predicted labels back to categorical value using MapKeyToValue transform.
   - Finally train model using Fit method

   ```c#
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
   
   ITransformer trainedModel = trainingPipeline.Fit(trainData);
   
   #endregion
   ```

   

3. Evaluate Model

4. Prediction

### Local

- - 

Let's get started. 

#### Create a Deep Neural Network for image classification

fads

##### ONNX



#### Create a local Azure function

fafa

#### Validate using Postman

### Cloud

- Prerequisites
  - Azure Function

#### Create a cloud Azure Function

fad

#### Validate using Postman

das

### Dockerize

## Results

## Conclusion

**Contact**













