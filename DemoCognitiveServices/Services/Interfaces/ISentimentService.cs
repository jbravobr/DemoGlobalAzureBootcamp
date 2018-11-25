using System;
using System.Threading.Tasks;

namespace DemoCognitiveServices.Services.Interfaces
{
    /// <summary>
    /// Sentiment service.
    /// </summary>
    public interface ISentimentService
    {
        /// <summary>
        /// Gets the sentiment.
        /// </summary>
        /// <returns>The sentiment.</returns>
        /// <param name="text">Text.</param>
        Task<double?> GetSentiment(string text);
    }
}
