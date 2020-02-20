using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class AssociationsDto
    {
        [JsonProperty("associatedCompanyIds")]
        public List<long> AssociatedCompanyIds { get; set; }

        [JsonProperty("associatedVids")]
        public List<long> AssociatedVids { get; set; }
    }
}
