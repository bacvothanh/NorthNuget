using Newtonsoft.Json;

namespace NN.GoogleRecaptcha.Domain.Models
{
    public class VerifyDto
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("remoteip")]
        public string RemoteIp { get; set; }
    }
}
