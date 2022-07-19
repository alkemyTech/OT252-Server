using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Repositories.Interfaces
{
    public interface IRepositoryNews:IRepository<News>
    { 
        
        IEnumerable<News> getAll();

        News getById(int id);

        void insert(News news);

        void update(News news);

        void delete(News news);

    }
}
