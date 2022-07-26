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
    }
}
