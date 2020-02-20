using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Contact
{
    public class ContactDto
    {
        [JsonProperty("vid")]
        public long VId { get; set; }

        [JsonProperty("isNew")]
        public bool IsNew { get; set; }
    }
}
