using System.Threading.Tasks;
using NN.Standard.Facebook.Domain.Models;
using RestEase;

namespace NN.Standard.Facebook.Domain.Clients
{
    public interface IRestFacebookService
    {
        [Get("access_token")]
        [AllowAnyStatusCode]
        Task<Response<AccessToken>> GetAccessToken([Query("grant_type")] string grantType, [Query("code")] string code, [Query("access_token")] string accessToken);

        [Get("me")]
        [AllowAnyStatusCode]
        Task<Response<Account>> GetAccountProfile([Query("access_token")] string accessToken);
    }
}
