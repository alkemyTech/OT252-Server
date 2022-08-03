using OngProject.Core.Models.DTOs;
using OngProject.Entities;
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
                Photo = user.Photo,


            };


            return userDto;
        }

        public Users ConvertToMember(UserDTO userDto)
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
    }
}
