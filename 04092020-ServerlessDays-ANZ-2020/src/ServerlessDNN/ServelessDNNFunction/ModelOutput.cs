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
