using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class SendGrid : ISendGrid
    {
        private IConfiguration _config;
        public SendGrid(IConfiguration config)
        {
            _config = config;
        }

        public Task WelcomeEmail(string email, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
}
