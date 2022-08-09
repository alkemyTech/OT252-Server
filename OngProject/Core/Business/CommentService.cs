using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
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
            return new CommentMapper().ConvertListToDto(await _unitOfWork.CommentRepository.GetAll());
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _unitOfWork.CommentRepository.Delete(await _unitOfWork.CommentRepository.GetById(id));
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<CommentDto> Update(int id, CommentDto commentDto)
        {
            try
            {
                mapper = new CommentMapper();
                Comment comment = await _unitOfWork.CommentRepository.GetById(id);

                if (comment == null)
                {
                    return null;
                }

                comment.Body = commentDto.Body;

                await _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.Save();

                CommentDto commentUpdated = mapper.ConverToDto(comment);

                return commentUpdated;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
