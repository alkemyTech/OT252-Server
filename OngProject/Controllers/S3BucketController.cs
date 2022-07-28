using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class S3BucketController : ControllerBase
    {

        private readonly IS3Service service;

        public S3BucketController(IS3Service service)
        {
            this.service = service;
        }

        [HttpPost("{bucketName}")]
        public async Task<IActionResult> CreateBucket([FromRoute] string bucketName)
        {
            var bucket = await service.CreateBucket(bucketName);
            return Ok(bucket);
        }
    }
}
