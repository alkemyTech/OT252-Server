using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class RepositoryNews : GenericRepository<News>, IRepositoryNews
    {
        public RepositoryNews(ApplicationDbContext context) : base(context)
        {
        }
    }
}
