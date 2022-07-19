using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OngProject.Core.Business
{
    public class RoleService :IRoleService
    {

        private UnitOfWork unitOfWork;

        public RoleService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        bool IRoleService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Role> IRoleService.Find(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Role> IRoleService.GetAll()
        {
            throw new NotImplementedException();
        }

        Role IRoleService.GetById(int? id)
        {
            throw new NotImplementedException();
        }

        Role IRoleService.Insert(Role role)
        {
            throw new NotImplementedException();
        }

        Role IRoleService.Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
