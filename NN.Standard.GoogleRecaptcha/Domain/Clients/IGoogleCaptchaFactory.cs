namespace NN.Standard.GoogleRecaptcha.Domain.Clients
{
    public interface IGoogleCaptchaFactory
    {
        IGoogleCaptchaRestService CreateRestService();
    }
}
