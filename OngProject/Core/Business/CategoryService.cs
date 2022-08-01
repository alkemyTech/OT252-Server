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
    public class CategoryService : ICategoryService
    {

        private IUnitOfWork _unitOfWork;
        private IImageHelper _imageHelper;
        private CategoryMapper _categoryMapper;


        public CategoryService(IUnitOfWork unitOfWork, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _categoryMapper = new CategoryMapper();
            _imageHelper = imageHelper;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
            {
                return false;
            }
            await _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
            return true;
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            var categoriesDto = _categoryMapper.categoryListDto(categories);
            return categoriesDto;
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            if(category == null)
            {
                return null;
            }
            var categoryDto = _categoryMapper.ConverToDto(category);
            return categoryDto;
            
        }

        public async Task<Category> Insert(CreationCategoryDto categoryDto)
        {
            var imgUrl = await _imageHelper.UploadImage(categoryDto.Image);
            var category = _categoryMapper.ConvertToCategory(categoryDto);
            category.Image = imgUrl.ToString();
            await _unitOfWork.CategoryRepository.Insert(category);
            _unitOfWork.Save();
            return category;
        }

        public Category Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
