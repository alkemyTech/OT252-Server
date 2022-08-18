using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public class RegisterMapper
    {
        public Users ConvertToUser(RegisterDTO dto)
        {
            var user = new Users
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                RoleId = dto.RoleId,
                TimeStamps = DateTime.UtcNow,
                SoftDelete = false
                

            };
            return user;
        }

        public LoginDto ConvertToUserLogin(Users user)
        {
            var login = new LoginDto
            {
                Email = user.Email,
                Token = user.Password,
                RoleId = user.RoleId

            };
            return login;
        }

        public ViewRegisterDto ConvertViewRegister(Users users)
        {
            var view = new ViewRegisterDto
            {
                Id = users.Id,
                Name = users.FirstName + " " + users.LastName,
                Email = users.Email,
                Photo = users.Photo,
                RoleId = users.RoleId
            };
            return view;
        }
    }
}
