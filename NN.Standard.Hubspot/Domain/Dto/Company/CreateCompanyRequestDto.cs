using System.Collections.Generic;
using Newtonsoft.Json;
using NN.Standard.Hubspot.Domain.Dto.Shared;

namespace NN.Standard.Hubspot.Domain.Dto.Company
{
    public class CreateCompanyRequestDto
    {
        [JsonProperty("properties")]
        public List<PropertyV2Dto> Properies { get; set; }
    }
}
