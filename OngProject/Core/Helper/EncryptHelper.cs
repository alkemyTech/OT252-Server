using System;
using System.Security.Cryptography;
using System.Text;

namespace OngProject.Core.Helper
{
    public static class EncryptHelper
    {
        public static string encriptar(string password)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            var hash = sha256.ComputeHash(encoding.GetBytes(password));
            var result = Convert.ToBase64String(hash);
            return result.Substring(0, 19);
        }
    }
}
