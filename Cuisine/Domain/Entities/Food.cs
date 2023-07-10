using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Food
    {
        [JsonProperty("nombre")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("precio")]
        public decimal Price { get; set; }
    }
}
