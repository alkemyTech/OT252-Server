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

using OngProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using OngProject.Repositories.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Mapper;


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

            var user = await _unitOfWork.UserRepository.GetById(id);
            if(user == null)
                return false;

            await _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Save();

            return true;

        }

        public IEnumerable<UserDTO> Find(Expression<Func<Users, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {

            return new UserMapper().ConvertListToDto(await unitOfWork.UserRepository.GetAll());  
        }



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
