# NorthNuget
Popular library integration

** Public in Nuget: https://www.nuget.org/profiles/bacvothanh

1. Google Recaptcha:
Verify google recaptcha token.
 ** How to use:
 Install: Install-Package NN.GoogleRecaptcha
 Or Install-Package NN.Standard.GoogleRecaptcha  // .net standrad version

- Register as a service in startup.cs:
  
        services.AddSingleton<IGoogleCaptchaFactory, GoogleCaptchaFactory>()
                .AddSingleton<IGoogleCaptchaService, GoogleCaptchaService>();
                
                
Then use in controller or anywhere you need:


        private readonly IGoogleCaptchaService _googleCaptchaService;

        public HomeController(IGoogleCaptchaService googleCaptchaService)
        {
            _googleCaptchaService = googleCaptchaService;
        }
        
        // in method
        var verifyResult = await _googleCaptchaService.Verify(new VerifyDto
            {
                Secret = "", // the secret key provided by Google Recaptcha
                Response = model.GRecaptchaResponse // the response token which you have when user submited form
            });

2. Facebook:
Verify facebook code, and get access token from that code.
Use access token to get facebook account profile.

Install: Install-Package NN.Standard.Facebook

3. Hubspot (CRM platform):
Hubspot integration for create company, contact, deal, file information ...

Install: Install-Package NN.Standard.Hubspot

4. Image helper:
Compress, resize image.

Install: Install-Package NN.Standard.Image
 
