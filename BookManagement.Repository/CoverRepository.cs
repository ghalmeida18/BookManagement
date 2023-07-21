using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BookManagement.Model.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookManagement.Repository
{
    public class CoverRepository : ICoverRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _accessKey;
        private readonly string _bucketName;
        private readonly string _secret;
        private readonly string _buckerAcessPoint;

        public CoverRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessKey = _configuration["S3Access:AccessKey"] ?? "";
            _bucketName = _configuration["S3Access:BucketName"] ?? ""; ;
            _secret = _configuration["S3Access:Secret"] ?? ""; ;
            _buckerAcessPoint = _configuration["S3Access:BuckerAcessPoint"] ?? ""; ;
        }

        public void UploadImage(MemoryStream file, Guid id)
        {
            using var client = new AmazonS3Client(_accessKey, _secret, new AmazonS3Config { 
                UseArnRegion = true,
                RegionEndpoint = RegionEndpoint.EUWest2
            });

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = file,
                Key = id.ToString(),
                BucketName = _buckerAcessPoint,
                CannedACL = S3CannedACL.PublicRead
            };


            var fileTransferUtility = new TransferUtility(client);
            fileTransferUtility.Upload(uploadRequest);
        }

        public async Task<MemoryStream> GetImage(Guid id)
        {
            using var client = new AmazonS3Client(_accessKey, _secret, new AmazonS3Config
            {
                UseArnRegion = true,
                RegionEndpoint = RegionEndpoint.USEast2
            });

            var getRequest = new GetObjectRequest()
            {
                BucketName = _bucketName,
                Key = id.ToString()
            };

            var image = await client.GetObjectAsync(getRequest);

            MemoryStream memoryStream = new();

            image.ResponseStream.CopyTo(memoryStream);

            return memoryStream;

        }
    }
}
