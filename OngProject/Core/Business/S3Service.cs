using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using OngProject.Core.Interfaces;

using OngProject.Entities;

using OngProject.Core.Models;

using System;
using System.Net;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 client;

        public S3Service(IAmazonS3 client)
        {
            this.client = client;
        }

        public async Task<S3Response> CreateBucket(string bucketName)
        {
            try
            {
                if (await AmazonS3Util.DoesS3BucketExistAsync(client, bucketName) is false)
                {
                    var putbacketRequest = new PutBucketRequest
                    {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };
                    var response = await client.PutBucketAsync(putbacketRequest);
                    return new S3Response
                    {
                        Message = response.ResponseMetadata.RequestId,
                        Status = response.HttpStatusCode
                    };
                }
            }
            catch(AmazonS3Exception e)
            {
                return new S3Response
                {
                    Status = e.StatusCode,
                    Message = e.Message
                };
            }
            catch(Exception e)
            {
                return new S3Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
            }

            return new S3Response
            {
                Status = HttpStatusCode.InternalServerError,
                Message = "Error"
            };
        }
    }
}
