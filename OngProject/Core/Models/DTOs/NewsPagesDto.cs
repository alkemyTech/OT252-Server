using OngProject.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class NewsPagesDto
    {
        public int ActualPage { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
        public int TotalElements { get; set; }
        public List<ViewNewsDto> news { get; set; }

        public NewsPagesDto(PageHelper<ViewNewsDto> helper)
        {
            ActualPage = helper.CurrentPage;
            NextPage = helper.IsPrevious ? $"api/News/GetAll?page={ActualPage + 1}" : null;
            PreviousPage = helper.HasPrevious ? $"api/News/GetAll?page={ActualPage - 1}" : null;
            TotalElements = helper.Count;

            news = helper;
        }
    }
}
