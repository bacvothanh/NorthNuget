using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class PropertyV1Dto
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
