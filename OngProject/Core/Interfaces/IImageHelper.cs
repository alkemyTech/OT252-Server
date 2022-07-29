using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IImageHelper
    {
        public Task<string> UploadImage(IFormFile file);
        public Task<string> UploadToS3(string base64, string namefile);
    }
}
