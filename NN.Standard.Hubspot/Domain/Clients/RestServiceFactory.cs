using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NN.Standard.Hubspot.Domain.Models;
using RestEase;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public class RestServiceFactory : IRestServiceFactory
    {
        private readonly HubspotConfig _config;

        public RestServiceFactory(HubspotConfig config)
        {
            _config = config;
        }

        public IHubspotRestService CreateHubspotService()
        {
            return CreateHubspotService(_config.BaseUri);
        }

        public IHubspotRestService CreateHubspotService(Uri baseUri)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = baseUri
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var restClient = new RestClient(httpClient)
            {
                JsonSerializerSettings = settings
            };

            var hubspotService = restClient.For<IHubspotRestService>();
            hubspotService.ApiKey = _config.ApiKey ?? throw new ArgumentNullException(nameof(_config.ApiKey));

            return hubspotService;
        }
    }
}
