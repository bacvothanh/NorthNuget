using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using NN.Standard.AWS.S3.Domain.Models;

namespace NN.Standard.AWS.S3.Application
{
    public class S3Service : IS3Service
    {
        private readonly BasicAWSCredentials _awsCredentials;
        private readonly S3Config _config;
        public S3Service(S3Config config)
        {
            _awsCredentials = new BasicAWSCredentials(config.S3AccessKey, config.S3AccessSecret);
            _config = config;
        }

        public async Task<string> UploadToS3(UploadModel model)
        {
            var fileKey = $"{Guid.NewGuid():N}{model.FileName}";
            var client = new AmazonS3Client(_awsCredentials, _config.Region);

            var response = await client.PutObjectAsync(new PutObjectRequest
            {
                BucketName = _config.BucketName,
                Key = fileKey,
                ContentType = model.ContentType,
                InputStream = model.Stream
            });

            if (response.HttpStatusCode == HttpStatusCode.OK)
                return GetPath(fileKey, _config.BucketName, _config.Region.SystemName);
            return string.Empty;
        }

        private string GetPath(string fileName, string bucketname, string region)
        {
            return $"{fileName}/{bucketname}/{region}";
        }

        public string GeneratePreSignedUrl(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || filePath.StartsWith("http://") || filePath.StartsWith("https://"))
                return filePath;

            return GeneratePreSignedUrl(filePath, new TimeSpan(2, 0, 0));
        }

        private string GeneratePreSignedUrl(string filePath, TimeSpan expire)
        {
            if (string.IsNullOrEmpty(filePath))
                return filePath;
            if (filePath.Contains("/") && filePath.Split('/')[0].Length > 2)
            {
                var fileKey = filePath.Split('/')[0];
                var bucketName = filePath.Split('/')[1];
                return GeneratePreSignedUrl(bucketName, fileKey, expire);
            }

            return string.Empty;
        }

        private string GeneratePreSignedUrl(string bucketName, string keyname, TimeSpan expire)
        {
            var s3Client = new AmazonS3Client(_awsCredentials, _config.Region);
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = keyname,
                Expires = DateTime.Now.Add(expire)
            };

            return s3Client.GetPreSignedURL(request);
        }
    }
}
