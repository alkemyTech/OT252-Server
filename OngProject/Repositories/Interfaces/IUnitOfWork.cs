using OngProject.Entities;
using System;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<Contact> ContactsRepository { get; }


        void Save();
    }
}
