using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class VersionDto
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("sourceVid")]
        public List<object> SourceVid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
