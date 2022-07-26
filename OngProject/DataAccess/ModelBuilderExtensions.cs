using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;

namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<News>()
                .HasData(
                     new News
                     {
                         Id = 1,
                         Name = "Clases de Refuerzo Escolar",
                         Content = "Gracias a la colaboracion de Docentes vecinos del barrio es que " +
                                  "logramos lanzar un proyecto para brindar apoyo escolar a los chicos " +
                                  "del barrio y barrios aledaños que lo necesiten.",
                         Image = "Agregar ruta de la imagen",
                         CategoryId = 2,      // Me base en las Categorias que agrego Lucas.
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
                         Content = "Gracias al apoyo del Gobierno Nacional ahora contamos con un nuevo aporte " +
                                   "economico que nos permitira brinadar 2 raciones alimentarias diarias a 200 " +
                                   "personas, pudiendo alcanzar no solo a familias del barrio de La Cava, sino " +
                                   "tambien de barrios aledños.",
                         Image = "Agregar ruta de la imagen",
                         CategoryId = 3,
                         TimeStamps = DateTime.Now,
                         SoftDelete = false
                     },
                     new News
                     {
                         Id = 4,
                         Name = "Donación Supermercado El Juanito",
                         Content = "El Supermercado el Juanito, se contacto con nosotros para apoyar a la Orgaización." +
                                   "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                                   "de pan por dia, esta aporte no resulta de ran ayuda para poder reforzar nuestras" +
                                   " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                         CategoryId = 4,      
                         TimeStamps = DateTime.Now,
                         SoftDelete = false
                     }
                );
        }
    }
}
