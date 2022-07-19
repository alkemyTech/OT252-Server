using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucket(string bucketName);
    }
}
