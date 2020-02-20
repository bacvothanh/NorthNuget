using System.Collections.Generic;
using Newtonsoft.Json;
using NN.Standard.Hubspot.Domain.Dto.Shared;

namespace NN.Standard.Hubspot.Domain.Dto.Deal
{
    public class CreateDealRequestDto 
    {
        [JsonProperty("associations")]
        public AssociationsDto AssociationsDto { get; set; }

        [JsonProperty("properties")]
        public List<PropertyV2Dto> Properties { get; set; }
    }
}
