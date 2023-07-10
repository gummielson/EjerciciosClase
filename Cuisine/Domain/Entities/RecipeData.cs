using Newtonsoft.Json;

namespace Domain.Entities
{
    public class RecipeData
    {
        [JsonProperty("nombre")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("ingredientes")]
        public Dictionary<string, decimal> Ingredients { get; set; } 

        [JsonProperty("minutosCocinado")]
        public int MinutesPerCooking { get; set; }
    }
}

