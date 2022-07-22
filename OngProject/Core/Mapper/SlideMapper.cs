using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class SlideMapper
    {
        public IEnumerable<SlideDto> ConvertListToDto(IEnumerable<Slide> listSlides)
        {
            List<SlideDto> listDtos = new List<SlideDto>();
            
            foreach (Slide slide in listSlides)
            {
                SlideDto slideDto = new SlideDto();
                slideDto.UrlImage = slide.ImageUrl;
                slideDto.Text = slide.Text;
                slideDto.Order = slide.Order;
                listDtos.Add(slideDto);
            }
            return listDtos;
        }
    }
}
