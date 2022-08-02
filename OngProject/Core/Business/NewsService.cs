﻿using OngProject.Core.Interfaces;
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
    public class NewsService : INewsService
    {

        private IUnitOfWork _unitOfWork;
        private IImageHelper _imageHelper;
        private NewsMapper _newsMapper;


        public NewsService(IUnitOfWork unitOfWork, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _newsMapper = new NewsMapper();
        }


        public async Task<bool> Delete(int id)
        {
            var news = await _unitOfWork.NewsRepository.GetById(id);
            if (news == null)
            {
                return false;
            }
            await _unitOfWork.NewsRepository.Delete(news);
            _unitOfWork.Save();
            return true;
        }

        public  IEnumerable<News> Find(Expression<Func<News, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<NewsDto> GetById(int? id)
        {
            var news =await _unitOfWork.NewsRepository.GetById(id);
            if (news == null)
            {
                return null;
            }
            var newsDto = _newsMapper.ConverToDto(news);
            return newsDto;
        }

        public async Task<News> Insert(CreationNewsDto newsDto)
        {
            var imgUrl = await _imageHelper.UploadImage(newsDto.Image);
            var news = _newsMapper.ConvertToNews(newsDto);
            news.Image = imgUrl.ToString();
            await _unitOfWork.NewsRepository.Insert(news);
            _unitOfWork.Save();
            return news;
        }

        public News Update(News news)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> FindComment(Expression<Func<Comment, bool>> predicate)
        {
            var comment = await _unitOfWork.CommentRepository.Find(predicate);
            if(comment == null)
            {
                return null;
            }
            return comment;
        }
    }
}
