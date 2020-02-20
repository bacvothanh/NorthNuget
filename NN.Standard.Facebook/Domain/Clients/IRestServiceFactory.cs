using NN.Standard.Facebook.Domain.Models;

namespace NN.Standard.Facebook.Domain.Clients
{
    public interface IRestServiceFactory
    {
        IRestFacebookService CreateFacebookService();
        FacebookConfig Config { get; set; }
    }
}
