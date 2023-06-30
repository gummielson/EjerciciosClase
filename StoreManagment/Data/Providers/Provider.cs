using System.Text.Json;
using Data.DataEntities;
using Data.ProviderContracts;
using Microsoft.Extensions.Configuration;

namespace Data.Providers
{
    public class Provider
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public Provider(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetAllUsers<T>(string entity)
        {
            using (var response = await _httpClient.GetAsync($"{_configuration[$"Endpoints:{entity}"]}"))
            {
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<T>>(responseAsString) ?? Enumerable.Empty<T>();
            }
        }
    }
}
