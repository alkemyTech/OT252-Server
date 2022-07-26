using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentDto>> GetAll();
    }
}
