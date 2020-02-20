using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NN.Standard.GoogleRecaptcha.Domain.Clients;
using RestEase;

namespace NN.GoogleRecaptcha.Domain.Clients
{
    public class GoogleCaptchaFactory : IGoogleCaptchaFactory
    {
        public IGoogleCaptchaRestService CreateRestService()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.google.com"),
                Timeout = TimeSpan.FromMinutes(3)
            };
            System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var restClient = new RestClient(httpClient)
            {
                JsonSerializerSettings = settings
            };

            var restService = restClient.For<IGoogleCaptchaRestService>();
            return restService;
        }
    }
}
