using OngProject.Core.Helper;
using System.Collections.Generic;

namespace OngProject.Core.Models.DTOs
{
    public class TestimonyPageDTO
    {

          public int ActualPage { get; set; }
            public string NextPage { get; set; }
            public string PreviousPage { get; set; }
            public int TotalElements { get; set; }
            public List<TestimonyDTO> testimonies { get; set; }

            public TestimonyPageDTO(PageHelper<TestimonyDTO> helper)
            {
                ActualPage = helper.CurrentPage;
                NextPage = helper.IsPrevious ? $"api/Testimonials/GetAll?page={ActualPage + 1}" : null;
                PreviousPage = helper.HasPrevious ? $"api/Testimonials/GetAll?page={ActualPage - 1}" : null;
                TotalElements = helper.Count;

                testimonies = helper;
            }
        }
    }

