using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Company
{
    public class CompanyListingDto
    {
        [JsonProperty("companies")]
        public List<CompanyDto> Companies { get; set; }

        [JsonProperty("has-more")]
        public bool HasMore { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}
