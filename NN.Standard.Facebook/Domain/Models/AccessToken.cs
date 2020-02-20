using Newtonsoft.Json;

namespace NN.Standard.Facebook.Domain.Models
{
    public class AccessToken
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("token_refresh_interval_sec")]
        public long TokenRefreshIntervalSec { get; set; }
    }
}
