using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class TestimonialsService : ITestimonialsService
    {
        private readonly TestimonyMapper mapper = new();

        private IUnitOfWork _unitOfWork;

        public TestimonialsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

            
            Testimony testimony = await _unitOfWork.TestimonialsRepository.GetById(id);

            if (testimony == null)
                throw new NullReferenceException($"No se encuentra el testimony con el id {id}");

            await _unitOfWork.TestimonialsRepository.Delete(testimony);

            _unitOfWork.Save();
            return true;

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocurrio un error al eliminar el id {id}: {ex.Message}");
            }
            


        }

        public IEnumerable<TestimonyDTO> Find(Expression<Func<Testimony, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestimonyDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TestimonyDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public TestimonyDTO Insert(TestimonyDTO testimonyDTO)
        {
            try
            {


            Testimony testimony = mapper.ToTestimony(testimonyDTO);

            _unitOfWork.TestimonialsRepository.Insert(testimony);
            _unitOfWork.Save();

             return mapper.ToTestimonyDTO(testimony);
            }
            catch (Exception)
            {

                throw new Exception("Error al ingresar los datos de testimony.");
            }

        }

        public TestimonyDTO Update(TestimonyDTO testimony)
        {
            throw new NotImplementedException();
        }
    }
}
