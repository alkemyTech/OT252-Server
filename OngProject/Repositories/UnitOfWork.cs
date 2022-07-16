using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {


        private ApplicationDbContext _context;
        private IGenericRepository<News> _newsRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public IGenericRepository<News> NewsRepository { 
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new GenericRepository<News>(_context);
                }
                return _newsRepository;
            }
        }
    }
}
