using Microsoft.AspNetCore.Mvc;
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
using OngProject.Core.Helper;

namespace OngProject.Core.Business
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IImageHelper _imageHelper;
        private UserMapper _mapper = new UserMapper();


        public UserService(IUnitOfWork unitOfWork, IImageHelper imageHelper, IUnitOfWork unitOfWork1, IUnitOfWork unitOfWork2)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;

        }

        public async Task<bool> Delete(int id)
        {

            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
                return false;

            user.SoftDelete = true;
            await _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
            return true;

        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            try
            {

                var users = await _unitOfWork.UserRepository.GetAll();

                List<UserDTO> usersDto = new();

                foreach (Users user in users)
                {
                    usersDto.Add(_mapper.ConvertToDto(user));
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
                if(user == null)
                {
                    return null;
                }
                UserDTO userDto = _mapper.ConvertToDto(user);

                return userDto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ViewUserDto> Update(int id, CreationUserDto userDto)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            var imageUrl = await _imageHelper.UploadImage(userDto.Photo);
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Password = EncryptHelper.GetSHA256(userDto.Password);
            user.Photo = imageUrl;
            user.RoleId = userDto.RoleId;
            _unitOfWork.Save();
            var userUpdate = _mapper.ConvertToViewUser(user);
            userUpdate.Password = userDto.Password;
            return userUpdate;
        }

        public Task<UserDTO> Insert(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users>> Find(Expression<Func<Users, bool>> predicate)
        {
            var user = await _unitOfWork.UserRepository.Find(predicate);
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<int> CheckUser(string email, int id)
        {
            int coincidencia = 0;
            int respuesta = 0;
            var users = await _unitOfWork.UserRepository.GetAll();
            _unitOfWork.Save();
            foreach (var user in users)
            {
                if(user.Id == id)
                {
                    coincidencia = 1;
                    break;
                }
            }
            if(coincidencia == 1)
            {
                foreach (var user2 in users)
                {
                    if(user2.Id != id && user2.Email == email)
                    {
                        respuesta = 2;
                        break;
                    }
                }
            }
            else
            {
                respuesta = 1;
            }
            if(coincidencia == 1 && respuesta == 0)
            {
                respuesta = 0;
            }
            return respuesta;
        }

        public async Task<int> CheckRole(int idRole)
        {
            var role = await _unitOfWork.RoleRepository.GetById(idRole);
            if(role == null)
            {
                return 1;
            }
            return 2;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}