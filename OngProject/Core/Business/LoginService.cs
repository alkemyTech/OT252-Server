using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class LoginService : ILoginService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ISendGrid _sendgrid;
        private RegisterMapper _mapper;
        private IImageHelper _imageHelper;

        public LoginService(IUnitOfWork unitOfWork, IConfiguration configuration, ISendGrid sendgrid, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _sendgrid = sendgrid;
            _imageHelper = imageHelper;
            _mapper = new RegisterMapper();
        }

        public async Task<string> GetToken(LoginDto usuario)
        {
            var user = await GetUser(usuario);
            var rol = await GetRole(usuario);
            List<Claim> claim = new();
            claim.Add(new Claim(type: "Id", user.Id.ToString()));
            claim.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claim.Add(new Claim(ClaimTypes.Role, rol.Name));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return token;
        }

        private async Task<Users> GetUser(LoginDto usuario)
        {
            var users = await _unitOfWork.UserRepository.Find(e => e.Email == usuario.Email);
            var user = users.FirstOrDefault();
            return user;
        }

        private async Task<Role> GetRole(LoginDto usuario)
        {
            var rol = await _unitOfWork.RoleRepository.GetById(usuario.RoleId);
            return rol;
        }

        public async Task<LoginDto> Login(string email, string password)
        {
            
            if (await Existeusuario(email))
            {
                LoginDto response = new LoginDto(); 
                var users = await _unitOfWork.UserRepository.Find(u => u.Email == email);
                var us = users.FirstOrDefault();
                if(us == null)
                {
                    return null;
                }
                if (!VerificarPassword(us.Password, password)) return null;
                var userlogin = _mapper.ConvertToUserLogin(us);
                var token = await GetToken(userlogin);
                response.Email = us.Email;
                response.RoleId = us.RoleId;
                response.Token = token;
                
                return response;
            }
            return null;
        }

        private bool VerificarPassword(string password, string pass)
        {
            return EncryptHelper.GetSHA256(pass) == password;
        }
        private async Task<bool> Existeusuario(string email)
        {
            var usuario = await _unitOfWork.UserRepository.Find(b => b.Email == email);
            if (usuario is null) return false;
            return true;
        }

        public async Task<Users> Register(RegisterDTO registerUser)
        {
            

            if (await ExistingEmail(registerUser.Email))
            {
                return null;
            }
            registerUser.Password = EncryptHelper.GetSHA256(registerUser.Password);
            var urlFoto = await _imageHelper.UploadImage(registerUser.Photo);
            var user = _mapper.ConvertToUser(registerUser);
            user.Photo = urlFoto;
            //var userlogin = mapper.ConvertToUserLogin(user);
            await _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
            await _sendgrid.WelcomeEmail(user.Email);
            //var token = await GetToken(userlogin);
            return user;
        }

        private async Task<bool> ExistingEmail(String email)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Email == email);
            return ((List<Users>)user).Count != 0;
        }
    }
}
