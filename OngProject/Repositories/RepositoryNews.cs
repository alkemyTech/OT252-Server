using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;

namespace OngProject.Repositories
{
    public class RepositoryNews : IRepositoryNews, IRepository<News>
    {


        public void delete(News news)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<News> getAll()
        {
            throw new System.NotImplementedException();
        }

        public News getById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void insert(News news)
        {
            throw new System.NotImplementedException();
        }

        public void update(News news)
        {
            throw new System.NotImplementedException();
        }
    }
}
