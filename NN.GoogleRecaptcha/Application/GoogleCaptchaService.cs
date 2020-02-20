using System;
using System.Threading.Tasks;
using NN.GoogleRecaptcha.Domain.Clients;
using NN.GoogleRecaptcha.Domain.Models;

namespace NN.GoogleRecaptcha.Application
{
    public class GoogleCaptchaService : IGoogleCaptchaService
    {
        private readonly IGoogleCaptchaFactory _googleCaptchaFactory;

        public GoogleCaptchaService(IGoogleCaptchaFactory googleCaptchaFactory)
        {
            _googleCaptchaFactory = googleCaptchaFactory;
        }

        public async Task<VerifyResponseDto> Verify(VerifyDto dto)
        {
            var service = _googleCaptchaFactory.CreateRestService();
            var response = await service.Verify(dto.Secret,dto.Response,dto.RemoteIp);
            if (response.ResponseMessage.IsSuccessStatusCode == false)
            {
                throw new Exception(response.StringContent);
            }

            return response.GetContent();
        }
    }
}
