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

        Task<IEnumerable<UserDTO>> GetAll();

        Task<UserDTO> GetById(int? id);

        IEnumerable<UserDTO> Find(Expression<Func<Users, bool>> predicate);

        Task<UserDTO> Insert(UserDTO user);
        UserDTO Update(UserDTO user);
        Task<bool> Delete(int id);



    }
}
