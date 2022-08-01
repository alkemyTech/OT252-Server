using OngProject.Core.Models;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUserService
    {
       
        UserResponse Login(string email, string password);
        string GetToken(UserResponse usuario);
        Task<IEnumerable<Users>> GetAllUsers();


    }
}
