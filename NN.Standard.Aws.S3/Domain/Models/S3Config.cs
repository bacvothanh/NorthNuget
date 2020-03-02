using Amazon;

namespace NN.Standard.AWS.S3.Domain.Models
{
    public class S3Config
    {
        public string BucketName { get; set; }
        public string S3AccessKey { get; set; }
        public string S3AccessSecret { get; set; }
        public RegionEndpoint Region { get; set; } = RegionEndpoint.USEast2;
    }
}
