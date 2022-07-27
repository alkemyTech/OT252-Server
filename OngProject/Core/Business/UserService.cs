
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UserService:IUserService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly IConfiguration configuration;
        public UserService(UnitOfWork uow, IConfiguration configuration)
        {
            this.unitOfWork = uow;
            this.configuration = configuration;
        }

        //public UserResponse Login(string emial, string password)
        //{
        //    if (ExisteUsuario(emial))
        //    {
        //        UserResponse response = new UserResponse();
        //        Users user = unitOfWork.UserRepository.GetByEmail(emial);
        //        if (!VerificarPassword (password, user.PasswordHash, user.PasswordSalt)) return null;
                
        //        response.Email = user.Email;
        //        response.RoleId = user.RoleId;
        //        response.UserId = user.Id;
        //        return response;
        //    }
        //    return null;
        //}
        private bool ExisteUsuario(string email)
        {
            var usuario = unitOfWork.UserRepository.Find(b => b.Email == email);
            if (usuario is not null)
                    return true;
            return false;
        }
        //private  Task<Users> GeyByEmail(string email)
        //{
        //    var usuario = unitOfWork.UserRepository.Find(b => b.Email == email).;
        //    return usuario;
            
        //}
        private bool VerificarPassword(string pass, byte[] pHash, byte[]pSalt)
        {
            var hMac = new HMACSHA512(pSalt);
            var hash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            for (var i = 0; i < hash.Length; i++)
                if (hash[i] != pHash[i]) return false;
            return true;
        }




        public string GetToken(UserResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserId.ToString()),
                new Claim(ClaimTypes.Role, usuario.Role.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials

            };
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
