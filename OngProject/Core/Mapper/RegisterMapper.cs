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
                Password = EncryptHelper.GetSHA256(dto.Password),
                Photo = dto.Photo,
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
                Password = user.Password,
                RoleId = user.RoleId

            };
            return login;
        }
    }
}
