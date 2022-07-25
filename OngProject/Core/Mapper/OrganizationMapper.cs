using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public class OrganizationMapper
    {

        public OrganizationDTO ToOrganizationDTO(Organization organization)
        {
            var organizationDto = new OrganizationDTO()
            {
               Name = organization.Name,
               Address = organization.Address,
               Email = organization.Email,
               Phone = organization.Phone,
               Image = organization.Image,
               AboutUsText = organization.AboutUsText,
               WelcomeText = organization.WelcomeText

            };

            return organizationDto;
        }

        public Organization ToOrganization(OrganizationDTO organizationDto)
        {
            var organization = new Organization()
            {
                Name = organizationDto.Name,
                Address = organizationDto.Address,
                Email = organizationDto.Email,
                Phone = organizationDto.Phone,
                Image = organizationDto.Image,
                AboutUsText = organizationDto.AboutUsText,
                WelcomeText = organizationDto.WelcomeText
            };

            return organization;
        }
    }
}
