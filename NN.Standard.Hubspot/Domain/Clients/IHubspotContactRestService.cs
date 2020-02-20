using System.Collections.Generic;
using System.Threading.Tasks;
using NN.Standard.Hubspot.Domain.Dto.Contact;
using NN.Standard.Hubspot.Domain.Dto.Shared;
using RestEase;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public interface IHubspotContactRestService
    {
        [Post("/contacts/v1/contact/createOrUpdate/email/{email}")]
        [AllowAnyStatusCode]
        Task<Response<ContactDto>> CreateOrUpdateContactsAsync([Path] string email, [Body] CreateContactRequestDto requestDto);

        [Post("properties/v1/contacts/properties")]
        Task<PropertyDefinitionDto> CreateContactPropertyDefinitionAsync([Body] PropertyDefinitionDto propertyDefinition);

        [Get("properties/v1/contacts/properties")]
        Task<List<PropertyDefinitionDto>> GetAllContactPropertiesAsync();
    }
}
