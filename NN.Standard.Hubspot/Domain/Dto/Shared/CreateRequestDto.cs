using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class CreateRequestDto<T>
    {
        [JsonProperty("properties")]
        public T Properies { get; set; }

        public CreateRequestDto(T propeties)
        {
            Properies = propeties;
        }
    }
}
