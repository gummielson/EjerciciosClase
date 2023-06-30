using System.Text.Json.Serialization;

namespace Data.DataEntities
{
    public class CartDataEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("products")]
        public Product[]? Products { get; set; }
        [JsonPropertyName("__v")]
        public int V { get; set; }

        public class Product
        {
            [JsonPropertyName("productId")]
            public int ProductId { get; set; }
            [JsonPropertyName("quantity")]
            public int Quantity { get; set; }
        }

    }
}
