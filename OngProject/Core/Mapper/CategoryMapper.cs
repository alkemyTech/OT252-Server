using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public class CategoryMapper
    {
        public IEnumerable<CategoryDto> categoryListDto(IEnumerable<Category> categories)
        {
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (Category category in categories)
            {
                CategoryDto dto = new CategoryDto();
                dto.Id = category.Id;
                dto.Name = category.Name;
                dto.Description = category.Description;
                dto.Image = category.Image;
                categoryDtos.Add(dto);
            }
            return categoryDtos;
        }

        public CategoryDto ConverToDto(Category category)
        {
            var categoryDto = new CategoryDto()
            {
                Name = category.Name,
                Description = category.Description,
                Image = category.Image,
            };
         
            return categoryDto;
        }

        public Category ConvertToCategory(CreationCategoryDto categoryDto)
        {
            var category = new Category();
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            category.TimeStamps = DateTime.Now;
            category.SoftDelete = false;
            return category;
        }

        public ViewCategoryDto ConverToViewDto(Category category)
        {
            var categoryDto = new ViewCategoryDto()
            {
                Name = category.Name,
                Description = category.Description,
                Image = category.Image,
            };

            return categoryDto;
        }
    }
}
