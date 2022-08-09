using Microsoft.AspNetCore.Authorization;
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
        // GET: api/Slide/GetAll
        /// <summary>
        /// Crea un nuevo objeto en la BD.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Crea un nuevo objeto en la BD.
        /// </remarks>
        /// <param name="pais">Objeto a crear a la BD.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
     /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>

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

        public async Task<IEnumerable<SlideDto>> GetByOrganization(int? id)
        {
            mapper = new SlideMapper();

            var slides = await _unitOfWork.SlideRepository.GetAll();
            slides = slides.Where(s => s.OrganizationId == id).OrderBy(s=>s.Order).ToList();

            if (slides == null)
            {
                return null;
            }

            List<SlideDto> slidesDTO = new List<SlideDto>();

            foreach(Slide slide in slides)
            {
                slidesDTO.Add(mapper.ConverToDto(slide));
            }

          
            return slidesDTO;


        }

        public async Task<bool> Insert(SlideDto slideDto)
        {
            try
            {
                if (await GetOrder(slideDto))
                {
                    slideDto.UrlImage = await _imageHelper.UploadToS3(slideDto.UrlImage, slideDto.Order.ToString());
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

        public async Task<SlideDto> Update(int id,SlideDto slideDto)
        {
            mapper = new SlideMapper();
            Slide slide = await _unitOfWork.SlideRepository.GetById(id);
            if(slide == null)
            {
                return null;
            }

            slide.ImageUrl=slideDto.UrlImage;
            slide.Text=slideDto.Text;
            slide.Order=slideDto.Order;

            await _unitOfWork.SlideRepository.Update(slide);
            _unitOfWork.Save();

            SlideDto retornoDto = mapper.ConverToDto(slide);
            return retornoDto;
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
