using Newtonsoft.Json;

namespace NN.Standard.Facebook.Domain.Models
{
    public class Phone
    {
        /// <summary>
        /// +84976058463
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// 84
        /// </summary>
        [JsonProperty("country_prefix")]
        public string CountryPrefix { get; set; }

        /// <summary>
        /// 976058463
        /// </summary>
        [JsonProperty("national_number")]
        public string NationalNumber { get; set; }
    }
}
