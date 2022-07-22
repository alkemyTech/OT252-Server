using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Add Seed Data Activity
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Organización", Description = "Noticias propias sobre la organización", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Category { Id = 2, Name = "Educación", Description = "Noticias sobre educación y relacionadas con los programas educativos",
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Category { Id = 3, Name = "Finanzas", Description = "Noticias sobre las finanzas de la organización", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Category { Id = 4, Name = "Social", Description = "Noticias del ámbito social", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false }
                );
        }
    }
}
