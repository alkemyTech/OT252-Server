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
        private IImageHelper _imageHelper;

        public TestimonialsService(IUnitOfWork unitOfWork, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

            
            Testimony testimony = await _unitOfWork.TestimonialsRepository.GetById(id);

                if (testimony == null)
                    return false;

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

        public async Task<IEnumerable<TestimonyDTO>> GetAll()
        {
            var listTestimony = await _unitOfWork.TestimonialsRepository.GetAll();

            List<TestimonyDTO> listTestimonyDto = new ();

            foreach(Testimony testimony in listTestimony)
                {
                listTestimonyDto.Add(mapper.ToTestimonyDTO(testimony));
            }
            
            return listTestimonyDto;
        }

        public TestimonyDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<TestimonyDTO> Insert(CreationTestimonyDTO testimonyDTO)
        {
            try
            {


            Testimony testimony = mapper.ToTestimony(testimonyDTO);

            testimony.Image = await _imageHelper.UploadImage(testimonyDTO.Image);

            await _unitOfWork.TestimonialsRepository.Insert(testimony);
            _unitOfWork.Save();

             return mapper.ToTestimonyDTO(testimony);
            }
            catch (Exception)
            {

                throw new Exception("Error al ingresar los datos de testimony.");
            }

        }

        public async Task<TestimonyDTO> putActionTestimony(TestimonyDTO testimony, int id)
        {
            try
            {
            if (_unitOfWork.TestimonialsRepository.GetById(id) is null) return null;
            await _unitOfWork.TestimonialsRepository.Update(new TestimonyMapper().ToTestimony(testimony));
            _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            return testimony;
        }
    }
}
