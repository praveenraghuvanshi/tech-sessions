using Microsoft.ML.Data;

namespace Cricket
{
    /// <summary>
    /// Manages the score prediction 
    /// </summary>
    public class MatchScorePrediction
    {
        /// <summary>
        /// Total runs scored by the team at the specified ball
        /// </summary>
        [ColumnName("Score")]
        public float TotalScore { get; set; }
    }
}
