using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Engagement
{
    public class EngagementDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("portalId")]
        public int PortalId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("ownerId")]
        public int OwnerId { get; set; }

        /// <summary>
        /// EMAIL, CALL, MEETING, TASK, NOTE
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
