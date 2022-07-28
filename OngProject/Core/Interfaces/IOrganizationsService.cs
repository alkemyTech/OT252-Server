using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationsService
    {
        Task<IEnumerable<OrganizationDTO>> GetAll();

        Task<OrganizationDTO> GetById(int? id);

        Task<IEnumerable<OrganizationDTO>> Find(Expression<Func<Organization, bool>> predicate);

        Organization Insert(Organization organization);
        Organization Update(Organization organization);
        bool Delete(int id);
        

    }
}
