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
- Serverless Deployment
  - Local : Azure function and Storage emulator
  - Cloud: [Azure subscription (Only for cloud deployment to Azure Function)](https://azure.microsoft.com/en-in/) and Azure blobl storage

### Dataset

Dataset plays an important role in Machine learning and it's not only the count that matters, quality of image also matters. Quality such as size, lighting, blurriness etc. In order to keep things simple, I have considered few images only. As we are going use pre-trained model, we don't need much data for demonstration. This will give a pretty decent accuracy on the trained model. 

Its a good practice to divide the dataset into train, test and validation dataset. 

- **Train:** A train dataset comprise of major portion on which model is trained and features are extracted.
- **Validation:**  A validation dataset is used to evaluate the accuracy of trained model. 
- **Test:** A test dataset is used to make predictions using trained model.

<img src=".\assets\data-split.png" alt="Data Split" style="zoom:50%;" />

The dataset is further divided as per the classes to be predicted. In this case, its cat and dog.

Dataset folder is structured as below.

<img src=".\assets\dataset-folder-structure.png" alt="Dataset Folder Structure" style="zoom:80%;" />



Sample Images

<img src=".\assets\sample-images.png" alt="Sample Images" style="zoom:80%;" />



### Image Classification - Console Application(C#)

Now we'll create a console application for classifying an image as a cat or dog.

Open Visual Studio and create a new C# console project and name it as 'ServerlessDNN'.

Add a directory 'assets' and copy the 'Images' directory along with images of cats and dogs.

<img src=".\assets\vs-images.png" alt="Images directory" style="zoom:80%;" />



We'll create ML pipeline of building a ML model first, train it over existing data and evaluate it on validation data. Once we are convinced with the accuracy, we'll make predictions over test data.

<img src=".\assets\ml-pipeline.png" alt="ML Pipeline" style="zoom:80%;" />

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

   <img src=".\assets\vs-images-models.png" alt="Data Models" style="zoom:80%;" />

   

   **Load data**

   Navigate to Program.cs and declare below variable to access the path of assets just above the Main method

   ```c#
   private static string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../")); // x64
   private static string assetsRelativePath = Path.Combine(projectDirectory, "assets");
   private static string imagesRelativePath = Path.Combine(assetsRelativePath, "images");
   private static string trainRelativePath = Path.Combine(imagesRelativePath, "train");
   private static string testRelativePath = Path.Combine(imagesRelativePath, "test");
   private static string valRelativePath = Path.Combine(imagesRelativePath, "val");
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

   

   We create an helper method to create a ML pipeline to preprocess the data

   ```c#
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
   ```

   Code for building a model is as follows.

   ```c#
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
   ```

   

2. **Train Model**

   Now data is ready and model is ready to be trained. Training a deep neural network is the core of Machine learning task. During this task, a model processes the set of images provided and extract features such as edges, gradients, patterns and objects. These could be eyes, ears, nose etc. The model does a forward and a backward pass during and adjusts weights of the network in order to learn features better. 

   ML.Net ImageClassifierTrainer provides a set of options that could be leveraged to fine tune the model training. Some of them are explained below. In order to keep the tutorial simple, I have used a minimal set of options.

   Steps in training a model

   - Add nuget packages
     - Microsoft.ML.Vision
     - SciSharp.TensorFlow.Redist
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
   ```

   Training time might vary based on the selected architecture

   Sample output

   <img src=".\assets\dnn-training.png" alt="DNN Training" style="zoom:80%;" />

   The numbers are not that great as we have supplied very small number images.

   

3. **Evaluate Model**

   We'll evaluate the model on validation dataset in order to know how good is the model and if its ready to be consumed for making predictions. The steps in evaluating the model is as follows.

   - Load Validation data
   - Preprocess data
     - MapValueToKey - ML models expect input to be numerical, labels/class is string and needs to be converted to numeric
     - LoadRawImageBytes - Loads image for evaluating
   - Evaluate Model using Validation data
     - MulticlassClassification is used for evaluation and a metric will be returned
     - Metrics has different parameters such as accuracy, loss that helps determins if a model is good or bad.
   - Print Metrics

   ```c#
   private static void PrintMetrics(MulticlassClassificationMetrics metrics)
   {
       Console.WriteLine("\n............ Metrics ...........");
       Console.WriteLine($"Macro Accuracy: {(metrics.MacroAccuracy * 100):0.##}%");
       Console.WriteLine($"Micro Accuracy: {(metrics.MicroAccuracy * 100):0.##}%");
       Console.WriteLine($"LogLoss is: {metrics.LogLoss:0.##}, value close to 0 is better");
       Console.WriteLine(
       $"PerClassLogLoss is: {String.Join(" , ", metrics.PerClassLogLoss.Select(c => c.ToString("0.##")))}, value close to 0 is better");
   }
   
   ```

   

   ```c#
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
   ```

   Result:

   <img src=".\assets\model-evaluation.png" alt="Model Evaluation" style="zoom:80%;" />

   As seen from the result, model trained with just 10 images of each class(cat and dog), we got a fairly good accuracy of 90% and loss it also less. We'll now use this for predicting on images which model has never seen/trained on.

   

4. **Prediction**

   Metrics may vary due to varied reasons such as volume of data, ML algorithm and problem domain. Once we are convinced numbers are good enough and model is ready for deployment to application, we need to do a final check on the model on the dataset it has never seen. This is achieved through PredictionEngine in ML.Net. The steps in predicting a model is as follows.

   - Load Test dataset
   - Preprocess data
     - MapValueToKey - ML models expect input to be numerical, labels/class is string and needs to be converted to numeric
     - LoadRawImageBytes - Loads image for predicting
   - Create a Prediction Engine
   - Perform prediction and display the result

   ```c#
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
   ```

   Result:

   <img src=".\assets\model-prediction.png" alt="Model Prediction" style="zoom:80%;" />

   The results are phenomenal as we can see the mode did a good job of classifying a dog and cat with all correct predictions.

   

5. **Save Model**

   This is the last step in ML pipeline and ML.Net has an API to save the trained model which can be further used in different applications such as console, web API and Azure functions.

   Add model path to the list of directory/file paths

   ```c#
   private static string modelOutputPath = Path.Combine(assetsRelativePath, "model.zip");
   ```

   We'll use Model.Save() API to save the model to 'assets' folder with the name 'model.zip'

   ```c#
   #region Save Model
   
   Console.WriteLine("\n****** Save Model - Start *******");
   
   mlContext.Model.Save(
       model: trainedModel,
       inputSchema: null,
       filePath: modelOutputPath);
   
   Console.WriteLine($"\nModel saved to : {modelOutputPath}");
   #endregion
   ```


   <details>
    <summary><h2>Click for full source</h2></summary>
​    

   ```c#
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
   ```

   </details>

### Image Classification - Serverless (Azure Function) - Local

We have been successful in creating an ML pipeline and predicting the image for our problem statement of classifying the cat and dog images. This works fine in a console application, but we need our model to be accessible to other applications in order to be used for different use cases. In order to achieve this, we need to expose an endpoint(URL) and consume within a client application. Client applications should allow uploading an image and returning with a response having predicted value(cat or dog).

In Azure, we can achieve this using different options available such as Azure App service, Azure Functions. Azure App service uses App service plan and is more expensive compared to Azure Function which is serverless and billed based on usage only. We need an Azure subscription in order to use Azure Functions. Limited time subscription can be obtained on registration at [Azure portal](https://azure.microsoft.com/en-in/free/).

Steps in creating a image classification serverless function using Azure Function

- Create Azure Function project using visual studio - Http Trigger
- Add nuget packages
  - Microsoft.ML
- Add Http trigger function to the project
- Access model trained in ML pipeline in the function - model.zip
  - Local - Access from system drive
  - Cloud - Upload to Azure blob storage and access it from there.
- Load model
- Make prediction and return result as a response
- Validate Azure function endpoint through Postman REST client.

I'll first create Azure function locally using template present in Visual Studio. Once everything is working fine, I'll deploy azure function to cloud.

Let's create a new project and select 'Azure Function' from the project template and add this project to the existing solution.

<img src=".\assets\azure-function-template.png" alt="Azure Function Template" style="zoom:67%;" />



In the next dialog, give a name to the project 'ServerlessDNNFunction' and click create.

<img src=".\assets\azure-function-http-trigger.png" alt="Create project - Http Trigger" style="zoom:80%;" />

This will add a new project to ServerlessDNN solution. Build the solution, just to ensure there are no errors. A default funtion(Function1) will be added.

Rename 'Function1.cs' file to ClassifyImage.cs and ensure it gets change in the function attribute as well as shown below.

```c#
namespace ServelessDNNFunction
{
    public static class ClassifyImage
    {
        [FunctionName("ClassifyImage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
```

Press F5 to run the project and it should generate an endpoint like http://localhost:7071/api/ClassifyImage

<img src=".\assets\azure-function-endpoint.png" alt="Azure Function Endpoint" style="zoom:80%;" />

Hit the url in browser and message 'This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.' must be displayed.

Remove 'get' from the HttpTrigger attribute of the function as we only need 'post' to upload an image.

In order to upload an image from postman, create a POST request with above URL and select 'Body' as binary. Select a file by clicking on 'Select File' in the Body tab

<img src=".\assets\postman-post-request.png" alt="Postman POST request" style="zoom:80%;" />

Add below code in Azure function to read and save uploaded image to temp directory

- STEP-1: Save image to Temp path

```c#
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
```

Now, we need to load the saved model 'model.zip'.  The size is file around 159MB. The file can be  accessed through disk or Storage Blob. In order to keep the experience same for both local and cloud, I have used [storage emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) for storing/reading the model. The model can be uploaded through [Microsoft Azure Storage Explorer](https://azure.microsoft.com/en-in/features/storage-explorer/).

Please follow steps to create a container 'serverlessdnn' and upload model.zip

Launch Azure Storage Explorer and select 'Local & Attached' account.

<img src=".\assets\storage-explorer-create-blob.png" alt="Create Blob Container" style="zoom:80%;" />

Select 'serverlessdnn' and click on Upload to upload model.zip

<img src=".\assets\storage-explorer-upload.png" alt="Upload file to blob" style="zoom:80%;" />

<img src=".\assets\storage-explorer-upload-dialog.png" alt="Upload Model" style="zoom:80%;" />

Model will be uploaded to blob and available to be used.

<img src=".\assets\storage-explorer-model.png" alt="Uploaded Model" style="zoom:80%;" />

Navigate back to Azure function in visual studio. In order to load model we need to have below things

- Storage blob connection string : double click on local.settings.json file in project explorer

  <img src=".\assets\blob-storage-conn-string.png" alt="Blobl Storage Connection String" style="zoom:80%;" />

  

- Add input and output model schema(classes) in order to load model and make predictions along with InputData

  

  ```c#
  using System;
  
  namespace ServelessDNNFunction.DataModels
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

  ```c#
  using System;
  
  namespace ServelessDNNFunction.DataModels
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

  

- Add nuget package

  - Microsoft.ML 

  - Microsoft.ML.Vision

  - Microsoft.ML.ImageAnalytics

  - SciSharp.TensorFlow.Redist

  - Azure.Storage.Blobs

    

- STEP-2: Load Model

  We are going to load model from Azure storage blob. Open local.settings.json and replace with below content

  ```javascript
  {
      "IsEncrypted": false,
      "Values": {
          "AzureWebJobsStorage": "UseDevelopmentStorage=true",
          "FUNCTIONS_WORKER_RUNTIME": "dotnet",
          "CONTAINER_NAME": "serverlessdnn",
          "BLOB_FILE":  "model.zip"
      }
  }
  ```

  Add 'ReadModelFromBlob' method to read blob from container and return a stream of model.

  ```c#
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
  ```

  Now load the model with below call after saving the uploaded image

  ```c#
  // STEP-2: Load model
  var modelStream = ReadModelFromBlob();
  
  var mlContext = new MLContext(seed: 1);
  var trainedModel = mlContext.Model.Load(modelStream, out var modelInputSchema);
  ```

- STEP-3: Load Data

  ```c#
  // STEP-3: Load Data
  var testImages = ImageData.ReadFromFolder(tempPath, false);
  IDataView testData = mlContext.Data.LoadFromEnumerable(testImages);
  ```

- STEP-4:  Preprocess Data

  ```c#
  // STEP-4: Preprocess data
  var testPreprocessingPipeline = CreatePreprocessingPipeline(mlContext, tempPath);
  var testDataPreprocessed = testPreprocessingPipeline.Fit(testData).Transform(testData);
  IDataView testPredictionData = trainedModel.Transform(testDataPreprocessed);
  ```

- STEP-5: 

  ```c#
  // STEP-5: Create PredictionEngine and perform prediction
  PredictionEngine<ModelInput, ModelOutput> predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);
  IEnumerable<ModelOutput> predictions = mlContext.Data.CreateEnumerable<ModelOutput>(testPredictionData, reuseRowObject: true);
  
  var predictedValue = predictions?.FirstOrDefault().PredictedLabel;
  ```

- Result

  - Input image

    <img src=".\assets\input-cat.png" alt="Input - Cat" style="zoom:80%;" />

  - Predicted: Cat

    <img src=".\assets\predicted-cat.png" alt="Predicted Cat" style="zoom:80%;" />

  

### Image Classification - Serverless (Azure Function) - Cloud

Now we are going to deploy this function app on Cloud(Azure). We need an Azure subscription for it. Deploying to azure is pretty easy through Visual Studio. Steps in deploying the Azure Function to the cloud is as follows.

1. Prerequisites
   1. Azure Subscription
   2. Azure Resource Group
2. dfads

Copy ModelInput.cs and ModelOutput.cs

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



## References

- https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs
- https://blog.rasmustc.com/multipart-data-with-azure-functions-httptriggers/













