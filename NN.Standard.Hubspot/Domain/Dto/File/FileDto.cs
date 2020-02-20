using Newtonsoft.Json;

namespace NN.Standard.Hubspot.Domain.Dto.File
{
    public class FileDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("portal_id")]
        public int PortalId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("encoding")]
        public string Encoding { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }
        [JsonProperty("cloud_key")]
        public string CloudKey { get; set; }
        [JsonProperty("s3_url")]
        public string S3Url { get; set; }
        [JsonProperty("friendly_url")]
        public string FriendlyUrl { get; set; }
        [JsonProperty("alt_key")]
        public string AltKey { get; set; }
        [JsonProperty("alt_key_hash")]
        public string AltKeyHash { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("meta")]
        public MetaDto Meta { get; set; }
        [JsonProperty("created")]
        public long Created { get; set; }
        [JsonProperty("updated")]
        public long Updated { get; set; }
        [JsonProperty("deleted_at")]
        public int DeletedAt { get; set; }
        [JsonProperty("folder_id")]
        public object FolderId { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("cloud_key_hash")]
        public string CloudKeyHash { get; set; }
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        [JsonProperty("created_by")]
        public object CreatedBy { get; set; }
        [JsonProperty("deleted_by")]
        public object DeletedBy { get; set; }
        [JsonProperty("replaceable")]
        public bool Replaceable { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("alt_url")]
        public string AltUrl { get; set; }
        [JsonProperty("cdn_purge_embargo_time")]
        public object CdnPurgeEmbargoTime { get; set; }
        [JsonProperty("file_hash")]
        public string FileHash { get; set; }
    }
}
