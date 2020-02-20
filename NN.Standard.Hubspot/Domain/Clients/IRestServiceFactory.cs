using System;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public interface IRestServiceFactory
    {
        IHubspotRestService CreateHubspotService();
        IHubspotRestService CreateHubspotService(Uri baseUri);
    }
}
