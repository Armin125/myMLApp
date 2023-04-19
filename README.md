# myMLApp
This Application is build based of ML.NET Tutorial From Microsoft. (https://dotnet.microsoft.com/en-us/learn/ml-dotnet/get-started-tutorial/install)
But the data is from IMDB movies.  
First we need to install .NET desktop development workload. 
```
##Already have Visual Studio?
If you already have Visual Studio 2022, you can add the .NET desktop development workload:
```
Select the Windows key, type Visual Studio Installer, and press Enter.
If prompted, allow the installer to update itself.
If an update for Visual Studio 2022 is available, an Update button will be shown. Select it to update before modifying the installation.
Find your Visual Studio 2022 installation and select Modify.
Select .NET desktop development and make sure ML.NET Model Builder is selected on the right pane. Select the Modify button.

# Add machine learning
1.Right-click on the myMLApp project in Solution Explorer and select Add > Machine Learning Model.  (ref: Microsoft) 
2.In the Add New Item dialog, make sure Machine Learning Model (ML.NET) is selected.   (ref: Microsoft) 
3.Change the Name field to SentimentModel.mbconfig and select the Add button.   (ref: Microsoft) 

# Pick a scenario

Due to the type of this labeled data that has two category with 0 = negative and 1= positive ,we conclude that related to sentiment analysis of movies in IMDB. The sentiment analysers used for movie recommender platforms or applications. So we are facing with a data classification question. 
## In this case
In this problem we use th sentiment based on the customer review text. 
#Data Set Information: (https://archive.ics.uci.edu/ml/datasets/Sentiment+Labelled+Sentences)
This dataset was created for the Paper 'From Group to Individual Labels using Deep Features', Kotzias et. al,. KDD 2015


It contains sentences labelled with positive or negative sentiment.

=======
 Format:
=======
sentence score

=======
 Details:
=======
Score is either 1 (for positive) or 0 (for negative)
The sentences come from three different websites/fields:
```
imdb.com
amazon.com
yelp.com
```
For each website, there exist 500 positive and 500 negative sentences. Those were selected randomly for larger datasets of reviews.
We attempted to select sentences that have a clearly positive or negative connotaton, the goal was for no neutral sentences to be selected.

## In our case we have taken 1000 comments of movie fans from imdb.com.  

1.Now we select the csv datasets of imdb. Checking the Data preview in the visual studio. column zero is comments and column 1 is scores. so we collect the column 1 for labaling. 
2.We train the dataset for around 60 seconds. Larger datasets take more time. After the training we have got 4 calculated parameters as below: 
Best accuracy - This shows you the accuracy of the best model that Model Builder found. Higher accuracy means the model predicted more correctly on test data.
Best model - This shows you which algorithm performed the best during Model Builder's exploration.
Training time - This shows you the total amount of time that was spent training / exploring models.
Models explored (total) - This shows you the total number of models explored by Model Builder in the given amount of time.
(ref: Microsoft)
# Try out your model
In this part it is possible to predict based on the sample input. 
## In this case, 0 means negative sentiment and 1 means positive sentiment.

# Code generation
After training is completed, three files are automatically added as code-behind to the SentimentModel.mbconfig:

SentimentModel.zip: This file is the trained ML.NET model, which is a serialized zip file.
SentimentModel.consumption.cs: This file contains the model input and output classes and a Predict method that can be used for model consumption.
SentimentModel.training.cs: This file contains the training pipeline (data transforms, algorithm, and algorithm parameters) used to train the final model.
(ref: Microsoft)
## In the Consume step in Model Builder, a code snippet is provided which creates sample input for the model and uses the model to make a prediction on that input.

# Consume your model
The last step is to consume your trained model in the end-user application.

Replace the Program.cs code in your myMLApp project with the following code:
```
using MyMLApp;
// Add input data
var sampleData = new SentimentModel.ModelInput()
{
    Col0 = "not sure who was more lost - the flat characters or the audience, nearly half of whom walked out."
};

// Load model and predict output of sample data
var result = SentimentModel.Predict(sampleData);

// If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
Console.WriteLine($"Text: {sampleData.Col0}\nSentiment: {sentiment}");
```
Run myMLApp (select Ctrl+F5 or Debug > Start Without Debugging). You should see the following output, predicting whether the input statement is positive or negative.

![Screenshot 2023-04-19 021921](https://user-images.githubusercontent.com/88989474/232934845-011b3719-1d0f-41e3-8ea9-28b07764a767.jpg)
