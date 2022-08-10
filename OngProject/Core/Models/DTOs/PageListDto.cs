﻿using OngProject.Core.Helper;
using System.Collections.Generic;

namespace OngProject.Core.Models.DTOs
{
    public class PageListDto<T>
    {

        public int ActualPage { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
        public int TotalElements { get; set; }
        public PageHelper<T> listItems { get; set; }

        public PageListDto(PageHelper<T> helper,string controller)
        {
            ActualPage = helper.CurrentPage;
            NextPage = helper.IsPrevious ? $"api/{controller}/GetAll?page={ActualPage + 1}" : null;
            PreviousPage = helper.HasPrevious ? $"api/{controller}/GetAll?page={ActualPage - 1}" : null;
            TotalElements = helper.Count;

            listItems = helper;
        }

    }
}
