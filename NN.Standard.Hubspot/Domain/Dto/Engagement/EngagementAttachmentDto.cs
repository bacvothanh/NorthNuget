using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Engagement
{
    public class EngagementAttachmentDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
