using System.Net.Http;
using NN.Standard.Facebook.Domain.Models;
using RestEase;

namespace NN.Standard.Facebook.Domain.Clients
{
    public class RestServiceFactory : IRestServiceFactory
    {
        public RestServiceFactory(FacebookConfig config)
        {
            Config = config;
        }

        public IRestFacebookService CreateFacebookService()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = Config.Uri
            };
            var restClient = new RestClient(httpClient);

            return restClient.For<IRestFacebookService>();
        }

        public FacebookConfig Config { get; set; }
    }
}
