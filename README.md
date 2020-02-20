# NorthNuget
Popular library integration

1. Google Recaptcha:

 ** How to use:
 
- Register as a service in startup.cs:
  
        services.AddSingleton<IGoogleCaptchaFactory, GoogleCaptchaFactory>()
                .AddSingleton<IGoogleCaptchaService, GoogleCaptchaService>();
                
                
Then use in controller or anywhere you need:


 private readonly IGoogleCaptchaService _googleCaptchaService;

        public HomeController(IGoogleCaptchaService googleCaptchaService)
        {
            _googleCaptchaService = googleCaptchaService;
        }

 var verifyResult = await _googleCaptchaService.Verify(new VerifyDto
            {
                Secret = "", // the secret key provided by Google Recaptcha
                Response = model.GRecaptchaResponse // the response token which you have when user submited form
            });
