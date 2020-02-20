using System.Collections.Generic;
using System.Threading.Tasks;
using NN.Standard.Hubspot.Domain.Dto.Deal;
using NN.Standard.Hubspot.Domain.Dto.Shared;
using RestEase;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public interface IHubspotDealRestService
    {
        [Post("deals/v1/deal")]
        [AllowAnyStatusCode]
        Task<Response<DealDto>> CreateDealAsync([Body] CreateDealRequestDto requestDto);

        [Post("properties/v1/deals/properties")]
        [AllowAnyStatusCode]
        Task<Response<PropertyDefinitionDto>> CreateDealPropertyDefinitionAsync([Body] PropertyDefinitionDto propertyDefinition);

        [Get("properties/v1/deals/properties/")]
        Task<List<PropertyDefinitionDto>> GetAllDealPropertyDefinitionsAsync();
    }
}
