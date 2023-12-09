using Dace23Demo.Abstractions;
using Newtonsoft.Json;

namespace Dace23Demo.Implementation
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientWrapper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            T deserialized = JsonConvert.DeserializeObject<T>(responseContent);

            return deserialized;
        }
    }
}