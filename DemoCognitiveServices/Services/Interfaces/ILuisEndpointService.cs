using System;
using System.Threading.Tasks;
using DemoCognitiveServices.Models;

namespace DemoCognitiveServices.Services.Interfaces
{
    public interface ILuisEndpointService
    {
        /// <summary>
        /// Gets the luis response.
        /// </summary>
        /// <returns>The luis response.</returns>
        /// <param name="query">Query.</param>
        Task<LuisModelResponse> GetLuisResponse(string text);
    }
}
