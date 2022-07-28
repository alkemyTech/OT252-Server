﻿using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public SlideDto ConverToDto(Slide slide)
        {
            var slideDto = new SlideDto();
            slideDto.UrlImage = slide.ImageUrl;
            slideDto.Text = slide.Text;
            slideDto.Order = slide.Order;
            return slideDto;
        }

        public Slide ConvertToEntity(SlideDto dto)
        {
            var slide = new Slide();
            slide.ImageUrl = dto.UrlImage;
            slide.Text = dto.Text;
            slide.Order = dto.Order;
            slide.OrganizationId = 1;
            slide.SoftDelete = false;
            slide.TimeStamps = DateTime.UtcNow;
            return slide;
        }
    }
}
