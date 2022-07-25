﻿using OngProject.Entities;
using System;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Slide> SlideRepository { get;  }
        public IGenericRepository<Organization> OrganizationRepository { get; }
        void Save();
    }
}
