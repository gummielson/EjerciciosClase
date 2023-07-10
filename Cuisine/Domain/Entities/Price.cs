using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Price
    {
        [JsonProperty("CostePorMinuto")]
        public decimal PricePerMinute { get; set; }

    }
}
