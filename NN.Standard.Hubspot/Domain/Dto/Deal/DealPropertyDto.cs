using Newtonsoft.Json;
using NN.Standard.Hubspot.Domain.Dto.Shared;

namespace NN.Standard.Hubspot.Domain.Dto.Deal
{
    public class DealPropertyDto
    {
        [JsonProperty("amount")]
        public PropertyDto Amount { get; set; }

        [JsonProperty("dealstage")]
        public PropertyDto DealStage { get; set; }

        [JsonProperty("name")]
        public PropertyDto Name { get; set; }
    }
}
