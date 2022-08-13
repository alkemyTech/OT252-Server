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

        public async Task<List<NewsDto>> GetAll()
        {
            var listMember = await _unitOfWork.NewsRepository.GetAll();
            List<NewsDto> membersDto = (List<NewsDto>)_newsMapper.ConvertListToDto(listMember);
            return membersDto;
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

        public async Task<ViewNewsDto> Insert(CreationNewsDto newsDto)
        {
            var imgUrl = await _imageHelper.UploadImage(newsDto.Image);
            var news = _newsMapper.ConvertToNews(newsDto);
            news.Image = imgUrl.ToString();
            await _unitOfWork.NewsRepository.Insert(news);
            _unitOfWork.Save();
            var viewNewsDto = _newsMapper.ConverToViewDto(news);
            return viewNewsDto;
        }

        public async Task<ViewNewsDto> Update(CreationNewsDto news, int id)
        {
            
                News editNews = await _unitOfWork.NewsRepository.GetById(id);

                if (editNews == null)
                    return null;

            Category category = await _unitOfWork.CategoryRepository.GetById(news.CategoryId);

            if (category == null)
                throw new Exception("El id de la categoria no es correcto");


                var imgUrl = await _imageHelper.UploadImage(news.Image);

                editNews.Content = news.Content;
                editNews.Name = news.Name;
                editNews.Image = imgUrl.ToString();
                editNews.CategoryId = news.CategoryId;
                editNews.Content = news.Content;
                editNews.TimeStamps = DateTime.Now;

                await _unitOfWork.NewsRepository.Update(editNews);
            _unitOfWork.Save();

                return _newsMapper.ConverToViewDto(editNews); 


            



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
