using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Testimony> Testimonials { get; set; }
        public DbSet<Slide> Slides { get; set; }

    }
}
