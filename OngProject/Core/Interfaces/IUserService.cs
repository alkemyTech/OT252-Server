using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<ViewUserDto>> GetAll();

        Task<UserDTO> GetById(int? id);

        Task<IEnumerable<Users>> Find(Expression<Func<Users, bool>> predicate);

        Task<UserDTO> Insert(UserDTO user);
        Task<ViewUserDto> Update(int id, CreationUserDto userDto);
        Task<bool> Delete(int id);

        Task<int> CheckUser(string email, int id);

        Task<int> CheckRole(int idRole);

        void Dispose();

    }
}
