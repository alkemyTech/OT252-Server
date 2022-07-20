using System.Net;

namespace OngProject.Core.Models
{
    public class S3Response
    {
        public  HttpStatusCode Status{ get; set; }
        public string Message { get; set; }
    }
}
