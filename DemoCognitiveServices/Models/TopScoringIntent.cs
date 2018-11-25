using System;
namespace DemoCognitiveServices.Models
{
    /// <summary>
    /// Top scoring intent.
    /// </summary>
    public class TopScoringIntent
    {
        /// <summary>
        /// Gets or sets the intent.
        /// </summary>
        /// <value>The intent.</value>
        public string Intent { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        public double Score { get; set; }
    }
}
