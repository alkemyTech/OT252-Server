using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OngProject.Controllers;
using OngProject.Core.Business;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestONGProject.Helpers;
using Xunit;

namespace Test_Ong.Controllers
{
    public class NewsControllerTest
    {
        public static ApplicationDbContext _context;
        public static UnitOfWork _unitOfWork;
        public static NewsService _newsServices;
        public static NewsController _newsController;
        public static CategoryService _categoryService;



        public NewsControllerTest()
        {
            var _config = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.test.json")
                      .Build();



            IImageHelper _imageHelper = new ImageHelper(_config);



            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "MemoryDBTest").Options;
            _context = new ApplicationDbContext(options);
            _unitOfWork = new(_context);
            _newsServices = new(_unitOfWork, _imageHelper);
            _categoryService = new(_unitOfWork, _imageHelper);
            _newsController = new(_newsServices, _categoryService);
            List<News> listNews = (List<News>)_unitOfWork.NewsRepository.GetAll().Result;
            List<Category> listCategory = (List<Category>)_unitOfWork.CategoryRepository.GetAll().Result;

            if (!(listNews.Count > 0))
            {
                List<News> list = new()
                {
                    new News
                    {
                        Id = 1,
                        Name = "Clases de Refuerzo Escolar",
                        Content = "Gracias a la colaboracion de Docentes vecinos del barrio es que " +
                        "logramos lanzar un proyecto para brindar apoyo escolar a los chicos " +
                        "del barrio y barrios aledaños que lo necesiten.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 2,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false
                    },
                    new News
                    {
                        Id = 2,
                        Name = "Futbol y Danza Juvenil",
                        Content = "Con la Ayuda del Club 25 de Mayo, lanzamos las clases de Futbol " +
                        "y Danza para los jovenes del barrio, las mismas se impartiran " +
                        "los dias sabados por la mañana o la tarde dependiendo de la edad del chico.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false
                    },
                    new News
                    {
                        Id = 3,
                        Name = "Subsidio Nacional",
                        Content = "Ahora contamos con un nuevo aporte " +
                        "economico que nos permitira brinadar 2 raciones alimentarias diarias a 200 " +
                        "personas, pudiendo alcanzar tambien a barrios aledños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 3,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false
                    }
                };

                if (!(listCategory.Count > 0))
                {
                    List<Category> listcategory = new()
                    {
                        new Category
                        {
                            Id = 1,
                            Name = "Organización",
                            Description = "Noticias propias sobre la organización",
                            Image = "Agregar ruta de la imagen",
                            TimeStamps = DateTime.Now,
                            SoftDelete = false
                        },
                        new Category
                        {
                            Id = 2,
                            Name = "Educación",
                            Description = "Noticias sobre educación y relacionadas con los programas educativos",
                            Image = "Agregar ruta de la imagen",
                            TimeStamps = DateTime.Now,
                            SoftDelete = false
                        },
                        new Category
                        {
                            Id = 3,
                            Name = "Finanzas",
                            Description = "Noticias sobre las finanzas de la organización",
                            Image = "Agregar ruta de la imagen",
                            TimeStamps = DateTime.Now,
                            SoftDelete = false
                        }
                    };
                    _context.AddRange(list);
                    _context.AddRange(listcategory);
                    _context.SaveChanges();
                }
            }



        }



        [Fact]
        public async Task GetAll_ShouldGetAllContact()
        {
            //Arrange

            //Act

            var result = await _newsController.GetAll();
            OkObjectResult okResult = (OkObjectResult)result.Result;



            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);


        }

        [Theory]
        [InlineData(200, 3)]
        [InlineData(404, 8)]
        public async Task Get_ShouldGetNewById(int statusCode, int newId)
        {
            //Arrange

            //Act

            ObjectResult result = (ObjectResult)(await _newsController.Get(newId)).Result;

            //Assert

            Assert.Equal(statusCode, result.StatusCode);

        }

        /*[Fact]
        public async Task Post_ShouldInsertNew_News()
        {
            //Arrange
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");

            CreationNewsDto news = new CreationNewsDto()
            {
                Name = "Nueva noticia",
                Content = "Este es el contenido",
                Image = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt"),
                CategoryId = 2
            };
            //Act

            ObjectResult result = (ObjectResult)(await _newsController.Post(news));

            //Assert

            Assert.Equal(200, result.StatusCode);
        }*/

        [Theory]
        [InlineData(200, 2)]
        [InlineData(404, 8)]
        public async Task Put_ShouldEditNews(int statusCode, int newsId)
        {
            //Arrange
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            CreationNewsDto newsDto = new CreationNewsDto
            {

                Name = "Nueva noticia",
                Content = "Este es el contenido",
                Image = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt"),
                CategoryId = 2

            };

            //Act

            ObjectResult result = (ObjectResult)(await _newsController.Put(newsDto, newsId)).Result;

            //Assert

            Assert.Equal(statusCode, result.StatusCode);
        }

        //[Theory]
        //[InlineData(15)]
        //public async Task Put_ShouldEditNewsException(int newsId)
        //{
        //    //Arrange
        //    var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
        //    CreationNewsDto newsDto = new CreationNewsDto
        //    {

        //        Name = "Nueva noticia",
        //        Content = "Este es el contenido",
        //        Image = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt"),
        //        CategoryId = 2

        //    };

        //    //Act

        //    var result = await _newsServices.Update(newsDto, newsId);

        //    //Assert

        //    Assert.Throws<Exception>(() => result);
        //}

        //[Theory]
        //[InlineData(200, 2)]
        //[InlineData(400, 9)]
        //public async Task Delete_ShouldDeleteNew(int statusCode, int contactId)
        //{
        //    //Arrange

        //    //Act

        //    var result = (await _newsServices.Delete(contactId));

        //    //Assert

        //    Assert.NotNull(statusCode);
        //}

    }
}
