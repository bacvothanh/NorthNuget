using RestEase;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public interface IHubspotRestService : IHubspotCompanyRestService, IHubspotContactRestService, IHubspotDealRestService, IHubspotFileRestService
    {
        [Query("hapikey")]
        string ApiKey { get; set; }
    }
}
