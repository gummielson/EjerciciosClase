using Newtonsoft.Json;

namespace Domain.Entities
{
    public class BarrioEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Nombre")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("CosteM2")]
        public decimal CosteM2 { get; set; }
    }
}
