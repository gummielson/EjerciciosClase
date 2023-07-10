using Newtonsoft.Json;

namespace Domain.Entities
{
    public class AniadidoEntity
    {
        [JsonProperty("precioM2")]
        public decimal PrecioM2 { get; set; }
        [JsonProperty("precio")]
        public decimal Precio { get; set; }
    }
}
