using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class LoginService : ILoginService
    {

        private readonly UnitOfWork _unitOfWork;

        public LoginService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Register(RegisterDTO registerUser)
        {

            if (await ExistingEmail(registerUser.Email))
            {
                return null;
            }

            var user = new Users() {
                FirstName = registerUser.FirstName, 
                LastName = registerUser.LastName,
                Email = registerUser.Email, 
                Password = EncryptHelper.encriptar(registerUser.Password),
                Photo=registerUser.Photo,
                RoleId=0, //Aca debe ir el Rol de Usuario
            };
            
            await _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();

            var userDTO = new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Photo = user.Photo,
            };

            return userDTO;
        }

        private async Task<bool> ExistingEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Email == email);
            return user != null;
        }

    }
}
