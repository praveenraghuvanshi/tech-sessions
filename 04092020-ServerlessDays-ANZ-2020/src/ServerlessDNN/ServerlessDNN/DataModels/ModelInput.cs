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
