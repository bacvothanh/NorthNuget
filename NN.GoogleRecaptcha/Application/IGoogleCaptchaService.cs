using System.Threading.Tasks;
using NN.GoogleRecaptcha.Domain.Models;

namespace NN.GoogleRecaptcha.Application
{
    public interface IGoogleCaptchaService
    {
        Task<VerifyResponseDto> Verify(VerifyDto dto);
    }
}
