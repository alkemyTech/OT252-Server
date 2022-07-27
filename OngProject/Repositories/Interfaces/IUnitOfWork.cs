using OngProject.Entities;
using System;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<News> NewsRepository { get;}
        IGenericRepository<Testimony> TestimonialsRepository { get; }
        IGenericRepository<Slide> SlideRepository { get; }
        IGenericRepository<Member> MemberRepository { get; }
        IGenericRepository<Activity> ActivitiyRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<Users> UserRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Organization> OrganizationRepository { get; }
        void Save();
    }
}
