# NorthNuget
Popular library integration

1. Google Recaptcha:
 ** How to use:
 
- Register as a service in startup.cs:
  
        services.AddSingleton<IGoogleCaptchaFactory, GoogleCaptchaFactory>()
                .AddSingleton<IGoogleCaptchaService, GoogleCaptchaService>();
                
                
