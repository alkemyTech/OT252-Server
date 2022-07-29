using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;


using SendGrid;
using SendGrid.Helpers.Mail;

using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task WelcomeEmail(string email)
        {
            var subject = "Bienvenido";
            var content = "Este es un mensaje de bienvenida";
            var apiKey = _config["ApiSendGrid"];
            var template = GetTemplate(subject, content);
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("alkemygrupo.252@gmail.com", "Grupo 252 C#");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", template);
            var response = await client.SendEmailAsync(msg);
        }

        public static string GetTemplate(string title, string content)
        {
            var outPutDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var FilePath = Path.Combine(outPutDirectory, "OngProject\\Templates\\emailtemplate.html");
            using (StreamReader sr = File.OpenText(FilePath))
            {
                string s = sr.ReadToEnd();
                s = s.Replace("Titulo", title);
                s = s.Replace("Texto del email", content);
                return s;
            }
       
        }
    }
}
