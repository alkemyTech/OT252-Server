using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class ImageHelper : IImageHelper
    {
        public IConfiguration _config;
        public ImageHelper(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> UploadImage(IFormFile file)
        {

            S3Section S3Data = _config.GetSection("S3").Get<S3Section>();
            var client = new AmazonS3Client(S3Data.PublicKey, S3Data.SecretKey, Amazon.RegionEndpoint.USEast1);
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = S3Data.BucketName,
                Key = file.FileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
                CannedACL = S3CannedACL.PublicRead
            };
            PutObjectResponse response = await client.PutObjectAsync(request);

            return $"https://{S3Data.BucketName}.s3.amazonaws.com/{file.FileName}";

        }


        public async Task<string> UploadToS3(string base64String, string filename)
        {
            try
            {
                S3Section S3Data = _config.GetSection("S3").Get<S3Section>();
                var client = new AmazonS3Client(S3Data.PublicKey, S3Data.SecretKey, Amazon.RegionEndpoint.USEast1);
                byte[] bytes = Convert.FromBase64String(base64String);

                using (client)
                {
                    var request = new PutObjectRequest
                    {
                        BucketName = S3Data.BucketName,
                        CannedACL = S3CannedACL.PublicRead,
                        Key = $"{filename}.jpg",
                    };
                    using (var ms = new MemoryStream(bytes))
                    {
                        request.InputStream = ms;
                        await client.PutObjectAsync(request);
                    }
                }
                return $"https://{S3Data.BucketName}.s3.amazonaws.com/{filename}.jpg";

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    public class S3Section
    {
        public string BucketName { get; set; }
        public string  SecretKey{ get; set; }
        public string PublicKey { get; set; }
        public string Region { get; set; }
    }

    
}
    




