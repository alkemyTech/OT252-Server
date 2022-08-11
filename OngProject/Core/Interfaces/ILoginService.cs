using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ILoginService
    {
        Task<Users> Register(RegisterDTO registerUser);
        Task<UserResponse> Login(string email, string password);
        Task<string> GetToken(LoginDto usuario);

    }
}
