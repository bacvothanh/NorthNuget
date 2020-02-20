using System.Threading.Tasks;
using NN.GoogleRecaptcha.Domain.Models;
using RestEase;

namespace NN.GoogleRecaptcha.Domain.Clients
{
    public interface IGoogleCaptchaRestService
    {
        [Post("recaptcha/api/siteverify")]
        [AllowAnyStatusCode]
        Task<Response<VerifyResponseDto>> Verify([Query] string secret, [Query] string response, [Query] string remoteip);
    }
}
