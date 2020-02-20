using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class PropertyDto
    {
        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("versions")]
        public List<VersionDto> Versions { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
