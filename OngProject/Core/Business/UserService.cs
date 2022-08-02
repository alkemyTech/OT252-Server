using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        private UserMapper mapper = new UserMapper();


        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> Find(Expression<Func<Users, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            try
            {

            var users = await _unitOfWork.UserRepository.GetAll();

            List<UserDTO> usersDto = new();

            foreach(Users user in users)
            {
                usersDto.Add(mapper.ConvertToDto(user));
            }

            return usersDto;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<UserDTO> GetById(int? id)
        {
            try
            {

                var user = await _unitOfWork.UserRepository.GetById(id);

                UserDTO userDto = mapper.ConvertToDto(user);

                return userDto;

            }
            catch (Exception)
            {

                throw;
            }
        }


        

        public UserDTO Update(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Insert(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
