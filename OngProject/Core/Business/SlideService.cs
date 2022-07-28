using Microsoft.AspNetCore.Http;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlideService : ISlideService
    {
        private IUnitOfWork _unitOfWork;
        private IImageHelper _imageHelper;
        private SlideMapper mapper;

        public SlideService(IUnitOfWork unitOfWork, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
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

        public async Task<bool> Insert(SlideDto slideDto)
        {
            try
            {
                if (await GetOrder(slideDto))
                {
                    await _imageHelper.UploadToS3(slideDto.UrlImage, slideDto.Order.ToString());
                    mapper = new SlideMapper();
                    var slide = mapper.ConvertToEntity(slideDto);
                    await _unitOfWork.SlideRepository.Insert(slide);
                    _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ImageBase64(string url)
        {


            byte[] bytes = Convert.FromBase64String(url);
            MemoryStream stream = new MemoryStream(bytes);
            File.WriteAllBytes(@"C:\Users\User\Desktop\prueba.jpg", bytes);



        }

        public Slide Update(Slide slide)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetOrder(SlideDto dto)
        {
            var slides = await _unitOfWork.SlideRepository.GetAll();
            foreach (var item in slides)
            {
                if (item.Order == dto.Order)
                {
                    return false;
                }
            }

            var lastOrder = slides.Last().Order;
            dto.Order = lastOrder + 1;
            return true;

        }
    }
}
