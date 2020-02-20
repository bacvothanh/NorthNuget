using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Engagement
{
    public class CreateEngagementDto
    {
        [JsonProperty("engagement")]
        public EngagementDto Engagement { get; set; }

        [JsonProperty("associations")]
        public EngagementAssociationsDto Associations { get; set; }

        [JsonProperty("attachments")]
        public List<EngagementAttachmentDto> Attachments { get; set; }

        [JsonProperty("metadata")]
        public EngagementMetadataDto Metadata { get; set; }
    }
}
