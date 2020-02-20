using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Engagement
{
    public class EngagementMetadataDto
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
