using System.Collections.Generic;
using System.Threading.Tasks;
using NN.Standard.Hubspot.Domain.Dto.Company;
using NN.Standard.Hubspot.Domain.Dto.Shared;
using RestEase;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public interface IHubspotCompanyRestService
    {
        [Get("companies/v2/companies/paged")]
        Task<CompanyListingDto> GetAllCompaniesAsync([Query] IEnumerable<string> properties, [Query]int limit = 100, [Query] long? offset = null);

        [Post("companies/v2/companies")]
        [AllowAnyStatusCode]
        Task<Response<CompanyDto>> CreateCompanyAsync([Body] CreateCompanyRequestDto requestDto);

        [Put("companies/v2/companies/{companyId}")]
        [AllowAnyStatusCode]
        Task<Response<CompanyDto>> UpdateCompanyAsync([Path] long companyId, [Body] CreateCompanyRequestDto requestDto);

        [Get("properties/v1/companies/properties")]
        [AllowAnyStatusCode]
        Task<Response<List<PropertyDefinitionDto>>> GetAllCompanyPropertyDefinitionsAsync();

        [Post("properties/v1/companies/properties")]
        Task<PropertyDefinitionDto> CreateCompanyPropertyDefinitionAsync([Body] PropertyDefinitionDto propertyDefinition);

        [Put("companies/v2/companies/{companyId}/contacts/{contactId}")]
        Task AddContactToCompanyAsync([Path] long companyId, [Path] long contactId);

        [Get("companies/v2/companies/{companyId}")]
        Task<CompanyDto> GetCompanyById([Path] long companyId);
    }
}
