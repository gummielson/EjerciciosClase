using System.Text.Json;
using Data.DataEntities;
using Data.ProviderContracts;

namespace Data.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly HttpClient _httpClient;

        public ProductProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDataEntity>> GetAllProducts()
        {
            using (var response = await _httpClient.GetAsync("https://fakestoreapi.com/products"))
            {
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<ProductDataEntity>>(responseAsString) ?? Enumerable.Empty<ProductDataEntity>();
            }
        }
    }
}
