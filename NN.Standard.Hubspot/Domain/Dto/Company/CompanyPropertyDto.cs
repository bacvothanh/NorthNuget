using Newtonsoft.Json;
using NN.Standard.Hubspot.Domain.Dto.Shared;

namespace NN.Standard.Hubspot.Domain.Dto.Company
{
    public class CompanyPropertyDto
    {
        [JsonProperty("name")]
        public PropertyDto Name { get; set; }

        [JsonProperty("description")]
        public PropertyDto Description { get; set; }

        [JsonProperty("kvk_nummer")]
        public PropertyDto KvkNumber { get; set; }
    }
}
