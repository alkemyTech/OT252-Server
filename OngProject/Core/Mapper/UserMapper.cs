using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class UserMapper
    {

        public UserDTO ConvertToDto(Users user)
        {
            UserDTO userDto = new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Photo = user.Photo
            };


            return userDto;
        }

        public Users ConvertToUser(UserDTO userDto)
        {
            Users user = new Users()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Photo = userDto.Photo,
            };
            return user;
        }

        public Users ConvertToUserC(Users user, CreationUserDto userDto)
        {
            user = new Users()
            {
                Id = user.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                RoleId = userDto.RoleId,
                TimeStamps = DateTime.Now,
                SoftDelete = false
            };
            return user;
        }

        public ViewUserDto ConvertToViewUser(Users users)
        {
            ViewUserDto userDto = new ViewUserDto()
            {
                Id = users.Id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                Photo = users.Photo,
                RoleId = users.RoleId

            };
            return userDto;
        }

    }
}
