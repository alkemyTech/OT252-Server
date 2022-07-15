using OngProject.DataAccess;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {


        private ApplicationDbContext _context;
        private ActivityRepository _activityRepository;
        private MemberRepository _memberRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }


        public ActivityRepository ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = new ActivityRepository(_context);
                }
                return _activityRepository;
            }
        }


        public MemberRepository MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new MemberRepository(_context);
                }
                return _memberRepository;
            }
        }
    }
}
