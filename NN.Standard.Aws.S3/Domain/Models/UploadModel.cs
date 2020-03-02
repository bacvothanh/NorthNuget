using System.IO;

namespace NN.Standard.AWS.S3.Domain.Models
{
    public class UploadModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Stream Stream { get; set; }
    }
}
