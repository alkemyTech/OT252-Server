using OngProject.Core.Models.DTOs;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ILoginService
    {
        Task<UserDTO> Register(RegisterDTO registerUser);
    }
}
