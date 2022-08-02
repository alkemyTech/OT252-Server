using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class CommentMapper
    {
        public IEnumerable<CommentDto> ConvertListToDto(IEnumerable<Comment> listComment)
        {
            List<CommentDto> listDtos = new List<CommentDto>();

            foreach (Comment comment in listComment)
            {
                CommentDto commentDto = new CommentDto();
                commentDto.Body = comment.Body;
                listDtos.Add(commentDto);
            }
            return listDtos;
        }
            public CommentDto ConverToDto(Comment comment)
            {
                var commentDto = new CommentDto();
                commentDto.Body = comment.Body;
                return commentDto;
            }
            public Comment ConverToEntity(CommentDto dto)
            {
                var comment = new Comment();
                comment.Body = dto.Body;
                return comment;
            }

    }
}
