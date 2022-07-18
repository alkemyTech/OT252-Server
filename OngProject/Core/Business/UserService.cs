using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        public UserService(UnitOfWork uow, IConfiguration configuration)
        {
            this.unitOfWork = uow;
            this.configuration = configuration;
        }
        public string GetToken(UserResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.RoleId, usuario.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.UserId, usuario.User),
                
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
