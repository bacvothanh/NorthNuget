using System.Threading.Tasks;
using NN.Standard.GoogleRecaptcha.Domain.Models;
using RestEase;

namespace NN.Standard.GoogleRecaptcha.Domain.Clients
{
    public interface IGoogleCaptchaRestService
    {
        [Post("recaptcha/api/siteverify")]
        [AllowAnyStatusCode]
        Task<Response<VerifyResponseDto>> Verify([Query] string secret, [Query] string response, [Query] string remoteip);
    }
}
