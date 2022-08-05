using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class NewsMapper
    {
        public List<NewsDto> ConvertListToDto(IEnumerable<News> listNews)
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

        public News ConvertToNews(CreationNewsDto newsDto)
        {
            var news = new News();
            news.Name = newsDto.Name;
            news.Content = newsDto.Content;
            news.CategoryId = newsDto.CategoryId;
            news.TimeStamps = DateTime.Now;
            news.SoftDelete = false;
            return news;
        }

        public ViewNewsDto ConverToViewDto(News news)
        {
            var newsDto = new ViewNewsDto();
            newsDto.Id = news.Id;
            newsDto.Name = news.Name;
            newsDto.Content = news.Content;
            newsDto.Image = news.Image;
            newsDto.CategoryId = news.CategoryId;
            return newsDto;
        }
    }
}
