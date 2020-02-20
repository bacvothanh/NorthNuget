using Newtonsoft.Json;

namespace NN.GoogleRecaptcha.Domain.Models
{
    public class VerifyResponseDto
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("hostname")]
        public string HostName { get; set; }
    }
}
