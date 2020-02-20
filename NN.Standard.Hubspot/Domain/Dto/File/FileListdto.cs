using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.File
{
    public class FileListDto
    {
        [JsonProperty("objects")]
        public List<FileDto> Objects { get; set; }
    }
}
