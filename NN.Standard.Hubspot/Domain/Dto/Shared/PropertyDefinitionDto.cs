using System.Collections.Generic;
using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.Shared
{
    public class PropertyDefinitionDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// string, number, bool, datetime, enumeration
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// textarea, select, text, date, file, number, radio, checkbox
        /// </summary>
        [JsonProperty("fieldType")]
        public string FieldType { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("options")]
        public List<OptionItemDto> Options { get; set; }
    }
}
