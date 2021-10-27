using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace ServerlessDNNFunction
{
    public class ModelOutput
    {
        [ColumnName("mobilenetv20_output_flatten0_reshape0")]
        public float[] Score { get; set; }
    }
}
