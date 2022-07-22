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
        private SlideMapper _slideMapper;

        public SlideService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _slideMapper = new SlideMapper();
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slide> Find(Expression<Func<Slide, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SlideDto>> GetAll()
        {
            IEnumerable<SlideDto> slideDtos = new List<SlideDto>();
            var slides = await _unitOfWork.SlideRepository.GetAll();
            var slidesDto = _slideMapper.ConvertListToDto(slides);
            return slidesDto;
        }

        public Slide GetById(int? id)
        {
            throw new NotImplementedException();
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
