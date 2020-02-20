namespace NN.GoogleRecaptcha.Domain.Clients
{
    public interface IGoogleCaptchaFactory
    {
        IGoogleCaptchaRestService CreateRestService();
    }
}
