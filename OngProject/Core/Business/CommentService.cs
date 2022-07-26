using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CommentService : ICommentsService
    {
        private IUnitOfWork _unitOfWork;
        private CommentMapper mapper;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            mapper = new CommentMapper();
            var comments = await _unitOfWork.CommentRepository.GetAll();
            var commentDto = mapper.ConvertListToDto(comments);
            return commentDto;
        }
    }
}
