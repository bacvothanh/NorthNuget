using System.Threading.Tasks;
using NN.Standard.AWS.S3.Domain.Models;

namespace NN.Standard.AWS.S3.Application
{
    public interface IS3Service
    {
        Task<string> UploadToS3(UploadModel model);
        string GeneratePreSignedUrl(string filePath);
    }
}
