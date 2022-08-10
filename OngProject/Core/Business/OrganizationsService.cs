using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly OrganizationMapper mapper = new OrganizationMapper();
        private readonly SlideMapper slideMapper = new SlideMapper();
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

                List<Slide> slides = (List<Slide>)await _unitOfWork.SlideRepository.GetAll();

                
                List<OrganizationDTO> listaDto = new List<OrganizationDTO>();

                foreach (Organization organization in lista)
                {
                    var organizationDto = mapper.ToOrganizationDTO(organization);
                    var slidesDto = slideMapper.ConvertListToDto(slides.Where(s => s.OrganizationId.Equals(organization.Id)).OrderBy(s => s.Order).ToList());
                    organizationDto.Slides = (List<SlideDto>)slidesDto;

                    listaDto.Add(organizationDto);
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
                if (organization == null)
                {
                    return null;
                }

                OrganizationDTO organizationDto = mapper.ToOrganizationDTO(organization);

                List<Slide> slides = (List<Slide>)await _unitOfWork.SlideRepository.GetAll();

                List<SlideDto> slidesDto = (List<SlideDto>)slideMapper.ConvertListToDto(slides.Where(s => s.OrganizationId.Equals(organization.Id)).OrderBy(s => s.Order).ToList());

                organizationDto.Slides = slidesDto;

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

        public async Task<Organization> Update(OrganizationDTO orgDto, int id)
        {
            var orgToUpdate = await _unitOfWork.OrganizationRepository.GetById(id);
            if (orgToUpdate != null)
            {
                var entityUpdated = mapper.UpdateModelWithDto(orgToUpdate, orgDto);
                await _unitOfWork.OrganizationRepository.Update(entityUpdated);
                _unitOfWork.Save();
                return entityUpdated;
            }
            else
            {
                return null;
            }

        }
    }
}
