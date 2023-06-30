using System.Text.Json.Serialization;

namespace Data.DataEntities
{
    public class ProductDataEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public float Price { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        [JsonPropertyName("rating")]
        public Rating RatingProperty { get; set; } = new Rating();

        public class Rating
        {
            [JsonPropertyName("rate")]
            public float Rate { get; set; }
            [JsonPropertyName("count")]
            public int Count { get; set; }
        }

    }
}
