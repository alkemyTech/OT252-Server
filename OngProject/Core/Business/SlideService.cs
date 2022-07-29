using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlideService : ISlideService
    {
        private IUnitOfWork _unitOfWork;

        private SlideMapper mapper;


        public SlideService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
            var slide = await _unitOfWork.SlideRepository.GetById(id);
            await _unitOfWork.SlideRepository.Delete(slide);
            _unitOfWork.Save();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Slide> Find(Expression<Func<Slide, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SlideDto>> GetAll()
        {
            mapper = new SlideMapper();
            var slides = await _unitOfWork.SlideRepository.GetAll();
            var slideDto = mapper.ConvertListToDto(slides);
            return slideDto;

        }

        public async Task<SlideDto> GetById(int? id)
        {
            mapper = new SlideMapper();
            var slide = await _unitOfWork.SlideRepository.GetById(id);
            if (slide == null)
            {
                return null;
            }
            var slideDto = mapper.ConverToDto(slide);
            return slideDto;

            
        }

        public Slide Insert(Slide slide)
        {
            throw new NotImplementedException();
        }

        public Slide Update(Slide slide)
        {
            throw new NotImplementedException();
        }
    }
}
