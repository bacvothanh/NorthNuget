using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class OptionItemDto
    {
        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("readOnly")]
        public object ReadOnly { get; set; }
        [JsonProperty("doubleData")]
        public object DoubleData { get; set; }
        [JsonProperty("description")]
        public object Description { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
