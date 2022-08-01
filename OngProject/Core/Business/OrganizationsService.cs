using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly OrganizationMapper mapper = new OrganizationMapper();
        private IUnitOfWork _unitOfWork;


     


        public OrganizationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrganizationDTO>> Find(Expression<Func<Organization, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrganizationDTO>> GetAll()
        {
            try
            {
                List<Organization> lista = (List<Organization>)await _unitOfWork.OrganizationRepository.GetAll();

                if (lista == null)
                    return new List<OrganizationDTO>();

                List<OrganizationDTO> listaDto = new List<OrganizationDTO>();

                foreach (Organization organization in lista)
                {
                    listaDto.Add(mapper.ToOrganizationDTO(organization));
                }

                return listaDto;
            }
            catch (Exception)
            {

                return new List<OrganizationDTO>();
            }
            
        }

        public async Task<OrganizationDTO> GetById(int? id)
        {
            try
            {
                Organization organization = await _unitOfWork.OrganizationRepository.GetById(id);

                OrganizationDTO organizationDto = mapper.ToOrganizationDTO(organization);
               
                return organizationDto;
            }
            catch (Exception)
            {

                return new OrganizationDTO();
            }
        }

        public Organization Insert(Organization organization)
        {
            throw new NotImplementedException();
        }

        public Organization Update(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
