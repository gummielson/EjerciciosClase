using System.Text.Json;
using Data.DataEntities;
using Data.ProviderContracts;

namespace Data.Providers
{
    public class CartProvider : ICartProvider
    {
        private readonly HttpClient _httpClient;

        public CartProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CartDataEntity>> GetAllCarts()
        {
            using (var response = await _httpClient.GetAsync("https://fakestoreapi.com/carts"))
            {
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<CartDataEntity>>(responseAsString) ?? Enumerable.Empty<CartDataEntity>();
            }
        }
    }
}
