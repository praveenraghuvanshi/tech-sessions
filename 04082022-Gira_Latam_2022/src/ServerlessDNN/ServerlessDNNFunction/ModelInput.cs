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
        [ImageType(ImageSettings.Height, ImageSettings.Width)]
        public Bitmap ImageSource { get; set; }
    }
}
