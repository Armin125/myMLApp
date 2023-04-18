﻿// See https://aka.ms/new-console-template for more information
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
