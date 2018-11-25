using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using DemoCognitiveServices.Models;
using DemoCognitiveServices.Services.Interfaces;
using Newtonsoft.Json;

namespace DemoCognitiveServices.Services
{
    /// <summary>
    /// Luis endoipt service.
    /// </summary>
    public class LuisEndoiptService : ILuisEndpointService
    {
        /// <summary>
        /// Gets the luis response.
        /// </summary>
        /// <returns>The luis response.</returns>
        /// <param name="query">Query.</param>
        public async Task<LuisModelResponse> GetLuisResponse(string text)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var luisAppId = "df85f719-7b42-4699-9280-001beffa80b8";
            var subscriptionKey = "f2b4cf14f7c74165b6cb8784b48600a4";

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            queryString["q"] = text;
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "false";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";

            var endpointUri = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/{luisAppId}?subscription-key={subscriptionKey}&{queryString}";
            var response = await client.GetAsync(endpointUri);

            var strResponseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LuisModelResponse>(strResponseContent);
        }
    }
}
