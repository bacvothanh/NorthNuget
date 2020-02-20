using Newtonsoft.Json;

namespace NN.Standard.Facebook.Domain.Models
{
    public class Account
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("phone")]
        public Phone Phone { get; set; }
    }
}
