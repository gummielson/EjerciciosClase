using Data.ProviderContracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Data.Provider
{
    public class Provider : IProvider
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public Provider(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string jsonName)
        {
            string apiUrl = _configuration[$"ExternalJSONs:{jsonName}"];

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody);

            return result ?? Enumerable.Empty<T>();
        }
    }
}