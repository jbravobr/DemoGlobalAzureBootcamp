using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DemoCognitiveServices.Services.Interfaces;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Rest;

namespace DemoCognitiveServices.Services
{
    /// <summary>
    /// Sentiment service.
    /// </summary>
    public class SentimentService : ISentimentService
    {
        //Base URL (Exemplo): https://westus.api.cognitive.microsoft.com
        const string _sentimentAPIBaseUrl = "https://brazilsouth.api.cognitive.microsoft.com/";
        const string _textSentimentAPIKey = "839d6dc11bcd46d2bb325556f686ebd7";

        //Wrapper HttpClient para acessar a API TextAnalytics
        readonly TextAnalyticsClient _textAnalyticsApiClient = new TextAnalyticsClient(new ApiKeyServiceClientCredentials(_textSentimentAPIKey))
        {
            Endpoint = _sentimentAPIBaseUrl
        };

        //Insira o texto a ser analisado e retorne sua pontuação de sentimento. A pontuação do sentimento varia de 0 a 1, onde 0 é sentimento negativo e 1 é sentimento positivo.
        public async Task<double?> GetSentiment(string text)
        {
            //Crie o objeto de solicitação para enviar para a API TextAnalytics
            //A solicitação pode conter várias entradas de texto que você pode usar para agrupar várias solicitações em uma chamada de API
            var request = new MultiLanguageBatchInput(new List<MultiLanguageInput>
            {
                {
                    new MultiLanguageInput(id: Guid.NewGuid().ToString(), text: text, language: "pt")
                }
            });

            //Obtendo os resultados do sentimento da API TextAnalytics 
            var sentimentResult = await _textAnalyticsApiClient.SentimentAsync(request);

            //Parse da pontuação do sentimento
            return sentimentResult?.Documents?.FirstOrDefault()?.Score;
        }

        //Classe auxiliar para adicionar nossa chave de API ao cabeçalho HttpRequestMessage
        class ApiKeyServiceClientCredentials : ServiceClientCredentials
        {
            /// <summary>
            /// The subscription key.
            /// </summary>
            readonly string _subscriptionKey;

            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="T:DemoCognitiveServices.Services.SentimentService.ApiKeyServiceClientCredentials"/> class.
            /// </summary>
            /// <param name="subscriptionKey">Subscription key.</param>
            public ApiKeyServiceClientCredentials(string subscriptionKey)
            {
                _subscriptionKey = subscriptionKey;
            }

            /// <summary>
            /// Processes the http request async.
            /// </summary>
            /// <returns>The http request async.</returns>
            /// <param name="request">Request.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

                return Task.CompletedTask;
            }
        }
    }
}