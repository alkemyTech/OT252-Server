using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly ApplicationDbContext context;
        private IGenericRepository<News> newsRepository;
        private IGenericRepository<Testimony> testimonialsRepository;

        private IGenericRepository<Slide> slideRepository;

        private IGenericRepository<Member> memberRepository;

        private IGenericRepository<Activity> activitiyRepository;

        private IGenericRepository<Role> roleRepository;

        private IGenericRepository<Users> userRepository;

        private IGenericRepository<Category> categoryRepository;

        private IGenericRepository<Organization> organizationRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            context = context;
           
        }
        public void Dispose(){ context.Dispose(); }

        public void Save() { context.SaveChanges(); }
        public IGenericRepository<Role> RoleRepository {
            get { if (roleRepository is null)
                    roleRepository = new GenericRepository<Role>(context);
                return roleRepository; }
        }

        public IGenericRepository<News> NewsRepository { 
            get
            {
                if (newsRepository == null)
                {
                    newsRepository = new GenericRepository<News>(context);
                }
                return newsRepository;
            }
        }

        public IGenericRepository<Testimony> TestimonialsRepository
        {
            get
            {
                if (testimonialsRepository == null)
                {
                    testimonialsRepository = new GenericRepository<Testimony>(context);
                }
                return testimonialsRepository;
            }
        }


        public IGenericRepository<Slide> SlideRepository
        {
            get
            {
                if (slideRepository == null)
                {
                    slideRepository = new GenericRepository<Slide>(context);
                }
                return slideRepository;
            }
        }


        public IGenericRepository<Member> MemberRepository
        {
            get
            {
                if (memberRepository == null)
                {
                    memberRepository = new GenericRepository<Member>(context);
                }
                return memberRepository;
            }
        }

        public IGenericRepository<Activity> ActivitiyRepository
        {
            get
            {
                if (activitiyRepository == null)
                {
                    activitiyRepository = new GenericRepository<Activity>(context);
                }
                return activitiyRepository;


            }
        }

        public IGenericRepository<Users> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<Users>(context);
                }
                return userRepository;


            }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;


            }
        }

        public IGenericRepository<Organization> OrganizationRepository
        {
            get
            {
                if (organizationRepository == null)
                {
                    organizationRepository = new GenericRepository<Organization>(context);
                }
                return organizationRepository;
            }
        }

    }
}
