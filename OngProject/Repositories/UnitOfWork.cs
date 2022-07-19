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
        private IGenericRepository<Role> _roleRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Role> RoleRepository {
            get { if (_roleRepository is null)
                    _roleRepository = new GenericRepository<Role>(_context);
                return _roleRepository; }
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
    }
}
