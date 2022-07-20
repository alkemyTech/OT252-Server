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

        private IGenericRepository<Slide> _slideRepository;

        private IGenericRepository<Member> _memberRepository;

        private IGenericRepository<Activity> _activitiyRepository;

        private IGenericRepository<Role> _roleRepository;

        private IGenericRepository<Users> _userRepository;

        private IGenericRepository<Category> _categoryRepository;

        private IGenericRepository<Organization> _organizationRepository;

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


        public IGenericRepository<Slide> SlideRepository
        {
            get
            {
                if (_slideRepository == null)
                {
                    _slideRepository = new GenericRepository<Slide>(_context);
                }
                return _slideRepository;
            }
        }


        public IGenericRepository<Member> MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new GenericRepository<Member>(_context);
                }
                return _memberRepository;
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

        public IGenericRepository<Users> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<Users>(_context);
                }
                return _userRepository;


            }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_context);
                }
                return _categoryRepository;


            }
        }

        public IGenericRepository<Organization> OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new GenericRepository<Organization>(_context);
                }
                return _organizationRepository;
            }
        }

    }
}
