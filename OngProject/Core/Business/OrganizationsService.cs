using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationsService : IOrganizationsService
    {

        private UnitOfWork _unitOfWork;

        public OrganizationsService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Organization> Find(Expression<Func<Organization, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Organization> GetAll()
        {
            throw new NotImplementedException();
        }

        public News GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public News Insert(Organization organization)
        {
            throw new NotImplementedException();
        }

        public News Update(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
