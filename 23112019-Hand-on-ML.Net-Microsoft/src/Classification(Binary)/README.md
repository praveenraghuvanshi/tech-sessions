

# Binary classification using ML.Net 

## Problem Statement: Predict the survival of traveler in Titanic ship tragedy

### Pre-requisites

- Visual Studio Code(Free IDE - https://code.visualstudio.com/download )/Visual Studio 2017 and above(Community edition - https://visualstudio.microsoft.com/)
- .Net Core SDK (Latest) : https://dotnet.microsoft.com/download
- C# Extensions : https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions
- ML.Net CLI : run 'dotnet tool install -g mlnet'



**Note:** Below instructions are for windows and can be used in a similar fashion on MacOS and Linux. Just change the path as per OS.

#### Setup

1. Create a directory on system such as "c:\binaryclassification" 

2. Open Visual Studio code(VSCode) -> File -> Open Folder -> Navigate to above directory and select it

3. Select 'New Terminal' from 'Terminal' at the top menu. It should open a command prompt within VS Code

4. Let's create a solution first for our projects. Enter below commands in terminal window

   > dotnet new sln --name binaryclassificationdemo

5. Create project : A console application

   > dotnet new console -o titanicbinaryclassification

6. Add project to solution
	
	> dotnet sln binaryclassificationdemo.sln add .\titanicbinaryclassification\titanicbinaryclassification.csproj

7. Navigate to titanicbinaryclassification directory

   > cd titanicbinaryclassification

8. Download titanic data from https://web.stanford.edu/class/archive/cs/cs109/cs109.1166/problem12.html

9. The data looks like below

| Survived | Pclass | Name                                                 | Sex    | Age  | Siblings Aboard | Parents Aboard | Fare    |
| -------- | ------ | ---------------------------------------------------- | ------ | ---- | --------------- | -------------- | ------- |
| 0        | 3      | Mr. Owen Harris Braund                               | male   | 22   | 1               | 0              | 7.25    |
| 1        | 1      | Mrs. John Bradley (Florence Briggs Thayer)   Cumings | female | 38   | 1               | 0              | 71.2833 |
| 1        | 3      | Miss. Laina Heikkinen                                | female | 0    | 0               | 0              | 7.925   |
| 1        | 1      | Mrs. Jacques Heath (Lily May Peel) Futrelle          | female | 35   | 1               | 0              | 53.1    |
| 0        | 3      | Mr. William Henry Allen                              | male   | 35   | 0               | 0              | 8.05    |

9. For the above data, we wanted to predict(Survived) survival of a traveler based on other features(PClass, Sex, Age, Siblings Aboard and Parents Aboard) available. 

10. Here 'Survived' is Label and other column(s) header are 'features'.

11. Create a directory 'data' and copy titanic.csv to it.

    > mkdir data

12. Open 'titanicbinaryclassification.csproj' in VSCode and copy below text just before </Project> tag. 'CopyToOutputDirectory' is important as it determines whether to copy titanic.csv to the application executing directory. 'PreserveNewest' allows copying of file in case there a new version of it. 

13. ```
    <ItemGroup>
    	<Content Include="data/titanic.csv"> 
        	<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
    </ItemGroup>
    ```


14. Navigate back to titanicbinaryclassification directory in VSCode explorer and create directory 'Schema'. Right-click on Schema directory and click on 'New C# class'. Give name of file as Passenger.cs file. File structure should be as shown below.

![](https://github.com/praveenraghuvanshi1512/AIML/blob/master/Meetup_DotNet_10_Aug_2019/Images/Folder_Structure_basic.png)

15. Install nuget package : Microsoft.ML by executing below command in Terminal

   > ```
   > dotnet add package Microsoft.ML
   > ```

16. Replace content of Passenger.cs with below code

17. ```  c#
    using Microsoft.ML.Data;
    
    namespace titanicbinaryclassification.Schema
    {
        public class Passenger
        {
            [LoadColumn(0)]
            public bool Survived { get; set; }
    
            [LoadColumn(1)]
            public float PClass { get; set; }
    
            [LoadColumn(2)]
            public string Name { get; set; }
    
            [LoadColumn(3)]
            public string Sex { get; set; }
    
            [LoadColumn(4)]
            public float Age { get; set; }
    
            [LoadColumn(5)]
            public float SiblingsAboard { get; set; }
    
            [LoadColumn(6)]
            public float ParentsAboard { get; set; }
        }
    }
    ```


#### Machine Learning using ML.Net

Applying ML.Net to .Net applications involves below basic steps

#### Load -> Transform -> Train -> Evaluate -> Save -> Predict

1. Open Program.cs

2. First step to create a model using ML.Net is to create an instance of MLContext. 

   MLContext is the core of ML.Net. It provides a way to create components for data preparation, feature engineering, training, prediction and model evaluation.

   Add below references at the top of Program.cs

   ``` c#
   using Microsoft.ML;
   using Microsoft.ML.Data;
   ```


   Inside Main method, instantiate MLContext

   `var mlContext = new MLContext();`

**Load :** Data from various sources such as file(text, csv), collection, binary is loaded to an object IDataView.

1. Load data from titanic.csv. Provide accurate path to file relative to current file, Program.cs.

2. As titanic.csv file has header, we need to set 'hasHeader' to true

3. We need to specify how records are separated. Being a csv file, specify comma ','.

4. ```c#
   Console.WriteLine("Load...");
   var data = mlContext.Data.LoadFromTextFile<Passenger>("Data/titanic.csv", hasHeader: true, separatorChar: ',');
   ```

5. Data is loaded and stored in 'data' variable

6. Working with full data is not a good practice, as model generated might not work well on new unseen data. In order to avoid that, it's always advised to split data into training and test data. Training data is used for training and generating model, however test data is used for validating the model.

   We specify 0.2 as test fraction which implies divide whole data with 80% training and 20% test data.

   ```c#
   var trainTestData = mlContext.Data.TrainTestSplit(data, 0.2); // Training/Test : 80/20
   ```
   

**Transform :** Transformation  of data is performed in order to make it suitable for training. We'll perform below transformations.

1. One-hot-encoding: Converting string/non-float to numeric : Sex field from Male/Female to 0/1

2. Replace missing values: In sample records table, age of Miss. Laina Heikkinen is missing and it has to be replaced with some meaningful value such as mean.

3. Concatenate: Merge features involved in model training

4. Add below namespace at the top of file

   ``` c#
   using static Microsoft.ML.Transforms.MissingValueReplacingEstimator;
   ```
5. Create Data Pipeline
   ```c#
   Console.WriteLine("Transform...");
               var dataProcessPipeline = mlContext.Transforms.Categorical.OneHotEncoding("Sex", "Sex")
                   .Append(mlContext.Transforms.ReplaceMissingValues("Age", replacementMode: ReplacementMode.Mean))
                   .Append(mlContext.Transforms.Concatenate("Features", "PClass", "Sex", "SiblingsAboard", "ParentsAboard"));
   ```

   

**Train :**  Training is performed on cleansed data. .

 1. Select algorithm: Selection is based on different types of algorithm such as Logistic Regression for a binary classification.

 2. Train Model

    ``` c#
    Console.WriteLine("Train...");
    var trainingPipeline = dataProcessPipeline.Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression("Survived"));
    var trainedModel = trainingPipeline.Fit(trainTestData.TrainSet);
    ```

    

**Evaluate :** In this step we evaluate the trained model to check how good/bad is it. It gives different parameters such as accuracy, precision etc.

1. As outcome is binary(survived/perished), we are using Binary Classification algorithm to evaluate model
2. Metrics is generated which has different type of result such as Accuracy, loss etc.

``` c#
// Evaluate 
Console.WriteLine("Evaluate...");
var predictions = trainedModel.Transform(trainTestData.TrainSet);
var metrics = mlContext.BinaryClassification.Evaluate(predictions, "Survived", "Score");
var accuracy = Math.Round(metrics.Accuracy * 100, 2);
Console.WriteLine($"Accuracy: {accuracy}%");
```



**Save :** Save generated model after training in binary format in order to use it in other applications such as desktop or web. 

1. Add reference to System.IO to be used by Path.Combine()

   ``` c#
   using System.IO;
   ```

2. Add below code for saving

   ``` c#
   Console.WriteLine("Save...");
   var savedPath = Path.Combine(Directory.GetCurrentDirectory(), "model.zip");
   mlContext.Model.Save(trainedModel, trainTestData.TrainSet.Schema, savedPath);
   Console.WriteLine("The model is saved to {0}", savedPath);
   ```

   

**Predict :** Here we make prediction on a sample data/record.

1. All algorithms create new columns after they have performed a prediction. The fixed names of these new columns depend on the type of machine learning algorithm. For the regression task, one of the new columns is called **Score**.

2. Add a new class 'PassengerPrediction' and replace with below code

   ```c#
   namespace titanicbinaryclassification
   {
       public class PassengerPrediction
       {
           public bool Prediction;
       }
   }
   ```

   

3. Go back to Program.cs and add below code for prediction

   1. Add reference to Schema namespace where Passenger class is present

      ``` c#
      using titanicbinaryclassification.Schema;
      ```

      

   2. Code for making prediction on a single record.

   ``` c#
   Console.WriteLine("*********** Predict...");
   var predictionEngine = mlContext.Model.CreatePredictionEngine<Passenger, PassengerPrediction>(trainedModel);
   var passenger = new Passenger()
   {
       PClass = 1,
       Name = "Mark Farragher",
       Sex = "male",
       Age = 48,
       SiblingsAboard = 0,
       ParentsAboard = 0
   };
   
   // make the prediction
   var prediction = predictionEngine.Predict(passenger);
   
   // report the results
   Console.WriteLine($"Passenger:   {passenger.Name} ");
   Console.WriteLine($"Prediction:  {(prediction.Prediction ? "survived" : "perished")} ");
   ```

   

4. Run program with below command one by one

   ```
   dotnet build
   dotnet run
   ```

5. Below output should be displayed with new Passenger predicted as perished

   ```
   PS C:\binaryclassification\titanicbinaryclassification> dotnet run
   Load...
   Transform...
   Train...
   Evaluate...
   Accuracy: 80.17%
   Save...
   The model is saved to C:\binaryclassification\titanicbinaryclassification\model.zip
   *********** Predict...
   Passenger:   Mark Farragher
   Prediction:  perished
   PS C:\binaryclassification\titanicbinaryclassification>
   ```



**Result:** Our model has a decent accuracy of 80.17% with Logistic Regression algorithm. Also, it has predicted on new unseen Passenger 'Mark Farragher' as Perished.

Trained model is saved as Model.zip. It can be used within different applications.



### AutoML - In Preview

ML.Net provides a way to automagically predict things by running different algorithms and generate code.

| S.No | Custom ML                                    | AutoML                                   |
| ---- | -------------------------------------------- | ---------------------------------------- |
| 1.   | Manually experiment with different algorithms| Runs different algorithms                |
| 2    | Time consuming in identifying best algorithm | Runs many algorithm without code changes |
| 3    | Provides better control of algorithms        | No control over algorithm selection      |
| 4    | Manually write code                          | Auto-generates code                      |

1. Install ML.Net CLI 

   ``` c#
   dotnet tool install -g mlnet
   ```

   

2. Navigate to path where titanic.csv is present.

3. Execute below command to run AutoML for a binary classification problem

   ``` c#
   mlnet auto-train --task binary-classification --dataset "titanic.csv" --label-column-index 0 --has-header true --max-exploration-time 30
   ```

   

4. It'll run different algorithms and produce below output

   ```
   PS C:\binaryclassification\titanicbinaryclassification\data> mlnet auto-train --task binary-classification --dataset "titanic.csv" --label-column-index 0 --has-header true --max-exploration-time 30
   Exploring multiple ML algorithms and settings to find you the best model for ML task: binary-classification
   For further learning check: https://aka.ms/mlnet-cli
   ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓Best Accuracy: 83.33%, Best Algorithm: SdcaLogisticRegressionBinary, Last Algorithm: AveragedPerceptronBinary                                                                                                         00:00:30
   ===============================================Experiment Results=================================================
   ------------------------------------------------------------------------------------------------------------------
   |                                                     Summary                                                    |
   ------------------------------------------------------------------------------------------------------------------
   |ML Task: binary-classification                                                                                  |
   |Dataset: titanic.csv                                                                                            |
   |Label : Survived                                                                                                |
   |Total experiment time : 30.54 Secs                                                                              |
   |Total number of models explored: 85                                                                             |
   ------------------------------------------------------------------------------------------------------------------
   |                                              Top 5 models explored                                             |
   ------------------------------------------------------------------------------------------------------------------
   |     Trainer                              Accuracy      AUC    AUPRC  F1-score  Duration #Iteration             |
   |1    SdcaLogisticRegressionBinary           0.8333   0.8933   0.8793    0.7547       0.2         53             |
   |2    SdcaLogisticRegressionBinary           0.8333   0.8913   0.8771    0.7636       0.7         74             |
   |3    AveragedPerceptronBinary               0.8205   0.8601   0.8522    0.7500       1.3          1             |
   |4    SdcaLogisticRegressionBinary           0.8205   0.8832   0.8677    0.7407       0.4          2             |
   |5    SdcaLogisticRegressionBinary           0.8205   0.8825   0.8640    0.7407       1.1         14             |
   ------------------------------------------------------------------------------------------------------------------
   Generated trained model for consumption: C:\binaryclassification\titanicbinaryclassification\data\SampleBinaryClassification\SampleBinaryClassification.Model\MLModel.zip
   Generated C# code for model consumption: C:\binaryclassification\titanicbinaryclassification\data\SampleBinaryClassification\SampleBinaryClassification.ConsoleApp
   Check out log file for more information: C:\binaryclassification\titanicbinaryclassification\data\SampleBinaryClassification\logs\debug_log.txt
   PS C:\binaryclassification\titanicbinaryclassification\data>
   ```



As you can see there is an improvement in accuracy (83.33%) with SdcaLogisticRegressionBinary algorithm compared to 80.17% from manual program. 
Code, model and logs path is also present to be used.

Full source code is available at https://github.com/praveenraghuvanshi1512/AIML/tree/master/Meetup_DotNet_10_Aug_2019/Source%20code/binaryclassification

This concludes a sample on Binary classification. Please leave a message for any suggestion/improvements.

Happy ML :-)
