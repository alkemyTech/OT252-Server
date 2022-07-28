using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class NewsMapper
    {
        public IEnumerable<NewsDto> ConvertListToDto(IEnumerable<News> listNews)
        {
            List<NewsDto> listDtos = new List<NewsDto>();

            foreach (News news in listNews)
            {
                NewsDto newsDto = new NewsDto();
                newsDto.Name = news.Name;
                newsDto.Content = news.Content;
                newsDto.Image = news.Image;
                listDtos.Add(newsDto);
            }
            return listDtos;
        }

        public NewsDto ConverToDto(News news)
        {
            var newsDto = new NewsDto();
            newsDto.Name = news.Name;
            newsDto.Content = news.Content;
            newsDto.Image = news.Image;
            return newsDto;
        }
    }
}
