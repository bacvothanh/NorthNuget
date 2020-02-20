using System.Collections.Generic;
using Newtonsoft.Json;
using NN.Standard.Hubspot.Domain.Dto.Shared;

namespace NN.Standard.Hubspot.Domain.Dto.Contact
{
    public class CreateContactRequestDto
    {
        [JsonProperty("properties")]
        public List<PropertyV1Dto> Properies { get; set; }
    }
}
