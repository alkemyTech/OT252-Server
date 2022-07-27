using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class SendGridHelper : ISendGrid
    {
        private IConfiguration _config;
        public SendGridHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task WelcomeEmail(string email, string _subject, string content)
        {
            var apiKey = _config["ApiSendGrid"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("alkemygrupo.252@gmail.com", "Usuario de Ejemplo");
            var subject = _subject;
            var to = new EmailAddress(email, email);
            var plainTextContent = content;
            var htmlContent = "<strong>mensaje de prueba</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
