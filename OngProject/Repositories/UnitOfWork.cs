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
        private IGenericRepository<Members> _memberRepository;

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

        public IGenericRepository<Members> MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new GenericRepository<Members>(_context);
                }
                return _memberRepository;
            }
        }
    }
}
