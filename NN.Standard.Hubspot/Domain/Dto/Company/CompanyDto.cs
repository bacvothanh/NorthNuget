using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Company
{
    public class CompanyDto
    {
        [JsonProperty("portalId")]
        public long PortalId { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("companyId")]
        public long CompanyId { get; set; }

        [JsonProperty("properties")]
        public CompanyPropertyDto Properties { get; set; }
    }
}
