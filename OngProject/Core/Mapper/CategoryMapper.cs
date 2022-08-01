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
                dto.Name = category.Name;
                categoryDtos.Add(dto);
            }
            return categoryDtos;
        }

        public CategoryDto ConverToDto(Category category)
        {
            var categoryDto = new CategoryDto();
            categoryDto.Name = category.Name;
         
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
    }
}
