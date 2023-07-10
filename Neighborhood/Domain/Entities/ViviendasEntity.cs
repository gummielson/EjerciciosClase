using Newtonsoft.Json;

namespace Domain.Entities
{
    public class ViviendasEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("IdBarrio")]
        public int IdBarrio { get; set; }
        [JsonProperty("M2")]
        public decimal M2 { get; set; }
        [JsonProperty("Añadidos")]
        public Dictionary<string, decimal> Aniadidos { get; set; } = new();
    }
}
