using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class LoginService : ILoginService
    {

        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Register(RegisterDTO registerUser)
        {
<<<<<<< Updated upstream
=======

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

            var user = new Users() {
                FirstName = registerUser.FirstName, 
                LastName = registerUser.LastName,
                Email = registerUser.Email, 
                Password = EncryptHelper.encriptar(registerUser.Password),
                Photo=registerUser.Photo,
                RoleId=2, //Aca debe ir el Rol de Usuario (Entiendo que 1 sería Administrador y 2 Usuario)
            };
            
            await _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();

        public async Task<UserResponse> Login(string email, string password)
        {
            //if (await Existeusuario(email))
            //{
            //    UserResponse response = new UserResponse();
            //    var users = await _unitOfWork.UserRepository.Find(u => u.Email == user.Email);
            //    var us = users.FirstOrDefault();
            //    if (!VerificarPassword(user.Password, password)) return null;

            //    response.Email = user.Email;
            //    response.RoleId = user.RoleId;
            //    response.RoleName = user.Role.Name;
            //    response.UserId = user.Id;
            //    return response;
            //}
            return null;
        }

        private bool VerificarPassword(string password, string pass)
        {
            return EncryptHelper.GetSHA256(pass) == password;
        }
        private async Task<bool> Existeusuario(string email)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Email == email);
            return ((List<Users>)user).Count!=0;
        }

>>>>>>> Stashed changes

            if (await ExistingEmail(registerUser.Email))
            {
                return null;
            }

            var user = new Users() {
                FirstName = registerUser.FirstName, 
                LastName = registerUser.LastName,
                Email = registerUser.Email, 
                Password = EncryptHelper.encriptar(registerUser.Password),
                Photo=registerUser.Photo,
                RoleId=2, //Aca debe ir el Rol de Usuario (Entiendo que 1 sería Administrador y 2 Usuario)
            };
            
            await _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();

            var userDTO = new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Photo = user.Photo,
            };

            return userDTO;
        }

<<<<<<< Updated upstream
        private async Task<bool> ExistingEmail(String email)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Email == email);
            return ((List<Users>)user).Count!=0;
        }



=======
>>>>>>> Stashed changes
    }
}
