using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {


        private ApplicationDbContext _context;
        private NewsRepository _newsRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }


        public NewsRepository NewsRepository { 
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_context);
                }
                return _newsRepository;
            }
        }
    }
}
