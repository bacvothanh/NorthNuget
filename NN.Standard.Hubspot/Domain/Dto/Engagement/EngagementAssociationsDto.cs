using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Engagement
{
    public class EngagementAssociationsDto
    {
        [JsonProperty("contactIds")]
        public List<object> ContactIds { get; set; }

        [JsonProperty("companyIds")]
        public List<object> CompanyIds { get; set; }

        [JsonProperty("dealIds")]
        public List<object> DealIds { get; set; }

        [JsonProperty("ownerIds")]
        public List<object> OwnerIds { get; set; }
    }
}
