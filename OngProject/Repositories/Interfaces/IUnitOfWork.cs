using OngProject.Entities;
using System;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         
        void Save();
    }
}
