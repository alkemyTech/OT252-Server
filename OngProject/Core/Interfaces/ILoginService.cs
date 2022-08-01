using OngProject.Core.Models.DTOs;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ILoginService
    {
        Task<string> Register(RegisterDTO registerUser);
    }
}
