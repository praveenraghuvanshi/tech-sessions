using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;

namespace ServerlessDNNFunction
{
    public class ModelInput
    {
        [ColumnName("Label"), LoadColumn(0)]
        public string Label { get; set; }

        [ImageType(ImageSettings.imageHeight, ImageSettings.imageWidth)]
        public Bitmap ImageSource { get; set; }
    }
}
