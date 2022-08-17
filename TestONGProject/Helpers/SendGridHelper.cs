using OngProject.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestONGProject.Helpers
{
    internal class SendGridTestHelper:ISendGrid
    {
        private string apiSendGrid = "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";

        public async Task WelcomeEmail(string email)
        {
            var subject = "Bienvenido";
            var content = "Este es un mensaje de test";
            var apiKey = apiSendGrid;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("alkemygrupo.252@gmail.com", "Grupo 252 C#");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, "");
            var response = await client.SendEmailAsync(msg);
        }


        public async Task ContactEmail(string email)
        {
            var subject = "Gracias por Contactarnos";
            var content = "Estamos felices que nos contactaras pronto te enviaremos un correo con mayor información";
            var apiKey = apiSendGrid;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("alkemygrupo.252@gmail.com", "Grupo 252 C#");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content,"");
            var response = await client.SendEmailAsync(msg);
        }


    }
}
