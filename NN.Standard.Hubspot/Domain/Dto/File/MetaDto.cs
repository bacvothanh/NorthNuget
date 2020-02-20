using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.File
{
    public class MetaDto
    {
        [JsonProperty("url_scheme")]
        public string UrlScheme { get; set; }

        [JsonProperty("allows_anonymous_access")]
        public bool AllowsAnonymousAccess { get; set; }
    }
}
