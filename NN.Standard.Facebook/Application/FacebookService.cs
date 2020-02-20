using System;
using System.Threading.Tasks;
using NN.Standard.Facebook.Domain.Clients;
using NN.Standard.Facebook.Domain.Models;

namespace NN.Standard.Facebook.Application
{
    public class FacebookService : IFacebookService
    {
        private readonly IRestServiceFactory _restServiceFactory;
        public FacebookService(IRestServiceFactory restServiceFactory)
        {
            _restServiceFactory = restServiceFactory;
        }

        public async Task<string> GetAccessTokenAsync(string code)
        {
            var client = _restServiceFactory.CreateFacebookService();
            var accessToken = $"AA|{_restServiceFactory.Config.AppId}|{_restServiceFactory.Config.AccountKitSecret}";
            var accessTokenResult = await client.GetAccessToken("authorization_code", code, accessToken);
            if (!accessTokenResult.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception(accessTokenResult.StringContent);
            }

            return accessTokenResult.GetContent().Token;
        }

        public async Task<Account> GetAccountKitAsync(string accessToken)
        {
            var client = _restServiceFactory.CreateFacebookService();
            var result = await client.GetAccountProfile(accessToken);
            if (!result.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception(result.StringContent);
            }

            return result.GetContent();
        }
    }
}
