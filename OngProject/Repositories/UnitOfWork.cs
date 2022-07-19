using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {


        private ApplicationDbContext _context;
        private IGenericRepository<News> _newsRepository;
        private IGenericRepository<Testimony> _testimonialsRepository;
        private IGenericRepository<Activity> _activitiyRepository;

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

        public IGenericRepository<Testimony> TestimonialsRepository
        {
            get
            {
                if (_testimonialsRepository == null)
                {
                    _testimonialsRepository = new GenericRepository<Testimony>(_context);
                }
                return _testimonialsRepository;
            }
        }

        public IGenericRepository<Activity> ActivitiyRepository
        {
            get
            {
                if (_activitiyRepository == null)
                {
                    _activitiyRepository = new GenericRepository<Activity>(_context);
                }
                return _activitiyRepository;
            }
        }
    }
}
