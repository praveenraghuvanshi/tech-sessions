using Microsoft.ML.Data;
using System.Text;

namespace Cricket
{
    /// <summary>
    /// Represents the input features involved in prediction
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Match venue
        /// </summary>
        [LoadColumn(0)]
        public string Venue { get; set; }

        /// <summary>
        /// Inning within a Match
        /// </summary>
        [LoadColumn(1)]
        public float Inning { get; set; }

        /// <summary>
        /// Current Ball being thrown
        /// </summary>
        [LoadColumn(2)]
        public float Ball { get; set; }

        /// <summary>
        /// Name of the batting team
        /// </summary>
        [LoadColumn(3)]
        public string BattingTeam { get; set; }

        /// <summary>
        /// Name of the bowling team
        /// </summary>
        [LoadColumn(4)] 
        public string BowlingTeam { get; set; }

        /// <summary>
        /// Batsman on strike
        /// </summary>
        [LoadColumn(5)]
        public string Striker { get; set; }

        /// <summary>
        /// Non striker batsman
        /// </summary>
        [LoadColumn(6)]
        public string NonStriker { get; set; }

        /// <summary>
        /// Current bowler
        /// </summary>
        [LoadColumn(7)]
        public string Bowler { get; set; }

        /// <summary>
        /// Total score till the current ball
        /// </summary>
        [LoadColumn(8)]
        public float TotalScore { get; set; }

        /// <summary>
        /// Gets the formatted string of Match object
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Venue: {Venue}");
            sb.Append($"\nBatting Team: {BattingTeam}");
            sb.Append($"\nBowling Team: {BowlingTeam}");
            sb.Append($"\nInning: {Inning}");
            sb.Append($"\nBall: {Ball}");
            sb.Append($"\nStriker: {Striker}");
            sb.Append($"\nNon-Striker: {NonStriker}");
            sb.Append($"\nBowler: {Bowler}");

            return sb.ToString();
        }
    }
}
