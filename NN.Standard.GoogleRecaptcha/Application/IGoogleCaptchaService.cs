using System.Threading.Tasks;
using NN.Standard.GoogleRecaptcha.Domain.Models;

namespace NN.Standard.GoogleRecaptcha.Application
{
    public interface IGoogleCaptchaService
    {
        Task<VerifyResponseDto> Verify(VerifyDto dto);
    }
}
