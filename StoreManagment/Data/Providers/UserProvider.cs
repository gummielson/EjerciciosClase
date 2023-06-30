using System.Text.Json;
using Data.DataEntities;
using Data.ProviderContracts;

namespace Data.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly HttpClient _httpClient;

        public UserProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDataEntity>> GetAllUsers()
        {
            using (var response = await _httpClient.GetAsync("https://fakestoreapi.com/users"))
            {
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<UserDataEntity>>(responseAsString) ?? Enumerable.Empty<UserDataEntity>();
            }
        }
    }
}
