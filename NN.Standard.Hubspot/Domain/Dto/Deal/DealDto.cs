using Newtonsoft.Json;
using NN.Standard.Hubspot.Domain.Dto.Shared;

namespace NN.Standard.Hubspot.Domain.Dto.Deal
{
    public class DealDto
    {
        [JsonProperty("portalId")]
        public long PortalId { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("dealId")]
        public long DealId { get; set; }

        [JsonProperty("associations")]
        public AssociationsDto AssociationsDto { get; set; }

        [JsonProperty("properties")]
        public DealPropertyDto Properties { get; set; }
    }
}
