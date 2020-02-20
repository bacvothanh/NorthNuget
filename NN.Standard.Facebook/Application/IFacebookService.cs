using System.Threading.Tasks;
using NN.Standard.Facebook.Domain.Models;

namespace NN.Standard.Facebook.Application
{
    public interface IFacebookService
    {
        Task<string> GetAccessTokenAsync(string code);
        Task<Account> GetAccountKitAsync(string accessToken);
    }
}
