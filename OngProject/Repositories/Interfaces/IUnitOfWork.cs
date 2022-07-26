using OngProject.Entities;
using System;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {


        IGenericRepository<Contact> ContactsRepository { get; }

        public IGenericRepository<Slide> SlideRepository { get;  }
        public IGenericRepository<Category> CategoryRepository { get; }

        void Save();
    }
}
