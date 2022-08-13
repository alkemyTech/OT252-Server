using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentService;
        private readonly IUnitOfWork unitOfWork;

       

        public CommentsController(ICommentsService commentService, IUnitOfWork unitOfWork)
        {
            this.commentService = commentService;
            this.unitOfWork = unitOfWork;
        }

        [Route("/comments")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            try
            {
                if (await commentService.GetAll() is null)
                    return NotFound();
                return Ok(await commentService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpPost]
        public ActionResult<Comment> Post(Comment comment)
        {
            if (unitOfWork.CommentRepository is null) return BadRequest();
            unitOfWork.CommentRepository.Insert(comment);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public void PutComments(int id, Comment comment)
        {
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {

            var response = commentService.Delete(id);
            if (response.Result) return Ok(true);
            return NotFound($"No se pudo eliminar no se encontro el comentario id: {id}");

        }
    }
}
