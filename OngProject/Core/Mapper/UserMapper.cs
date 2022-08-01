using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class UserMapper
    {
        public IEnumerable<UserDTO> ConvertListToDto(IEnumerable<Users> listUsers)
        {
            List<UserDTO> listDtos = new List<UserDTO>();

            foreach (Users users in listUsers)
            {
                UserDTO UserDto = new UserDTO();
                UserDto.FirstName = users.FirstName;
                UserDto.LastName = users.LastName;
                UserDto.Photo = users.Photo;
                UserDto.Email = users.Email;
                listDtos.Add(UserDto);
            }
            return listDtos;
        }

        public UserDTO ConvertToDto(Users users)
        {
            UserDTO UserDto = new UserDTO();
            UserDto.FirstName = users.FirstName;
            UserDto.LastName = users.LastName;
            UserDto.Photo = users.Photo;
            UserDto.Email = users.Email;

            return UserDto;
        }

        public Users ConvertToMember(UserDTO UserDto)
        {
            Users users = new Users();
            users.FirstName = UserDto.FirstName;
            users.LastName = UserDto.LastName;
            users.Photo = UserDto.Photo;
            users.Email = UserDto.Email;
            return users;
        }
    }
}
