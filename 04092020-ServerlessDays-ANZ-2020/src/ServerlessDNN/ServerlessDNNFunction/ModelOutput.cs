using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace ServerlessDNNFunction
{
    public class ModelOutput
    {
        // ColumnName attribute is used to change the column name from
        // its default value, which is the name of the field.
        [ColumnName("PredictedLabel")]
        public String Prediction { get; set; }

        [ColumnName("mobilenetv20_output_flatten0_reshape0")]
        public float[] Score { get; set; }
    }
}
