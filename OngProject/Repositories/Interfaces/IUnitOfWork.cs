using OngProject.Entities;
using System;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        public IGenericRepository<Slide> SlideRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<News> NewsRepository { get; }
        public IGenericRepository<Testimony> TestimonialsRepository { get; }
        public IGenericRepository<Member> MemberRepository { get; }
        public IGenericRepository<Activity> ActivityRepository { get; }
        public IGenericRepository<Role> RoleRepository { get; }
        public IGenericRepository<Users> UserRepository { get; }
        public IGenericRepository<Organization> OrganizationRepository { get; }
        public IGenericRepository<Contact> ContactsRepository { get; }
        public IGenericRepository<Comment> CommentRepository { get; }



        IGenericRepository<Contact> ContactsRepository { get; }

        public IGenericRepository<Slide> SlideRepository { get;  }

        public IGenericRepository<Organization> OrganizationRepository { get; }

        public IGenericRepository<Category> CategoryRepository { get; }


        void Save();
    }
}
