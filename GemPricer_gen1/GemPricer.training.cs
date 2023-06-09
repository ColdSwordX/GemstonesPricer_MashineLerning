﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace GemPricer_gen1
{
    public partial class GemPricer
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"cut", @"cut", outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"carat", @"carat"),new InputOutputColumnPair(@"color", @"color"),new InputOutputColumnPair(@"clarity", @"clarity"),new InputOutputColumnPair(@"x", @"x"),new InputOutputColumnPair(@"y", @"y"),new InputOutputColumnPair(@"z", @"z")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"cut",@"carat",@"color",@"clarity",@"x",@"y",@"z"}))      
                                    .Append(mlContext.Regression.Trainers.FastTree(new FastTreeRegressionTrainer.Options(){NumberOfLeaves=4,MinimumExampleCountPerLeaf=34,NumberOfTrees=613,MaximumBinCountPerFeature=336,FeatureFraction=0.878228781180061,LearningRate=0.999999776672986,LabelColumnName=@"price",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
