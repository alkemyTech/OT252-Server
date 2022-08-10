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
                Id = organization.Id,
                Name = organization.Name,
                Address = organization.Address,
                Email = organization.Email,
                Phone = organization.Phone,
                Image = organization.Image,
                AboutUsText = organization.AboutUsText,
                WelcomeText = organization.WelcomeText,
                FacebookUrl = organization.FacebookUrl,
                LinkedinUrl = organization.LinkedinUrl,
                InstagramUrl = organization.InstagramUrl,
            };

            return organizationDto;
        }

        public Organization ToOrganization(OrganizationDTO organizationDto)
        {
            var organization = new Organization()
            {
                Id=organizationDto.Id,
                Name = organizationDto.Name,
                Address = organizationDto.Address,
                Email = organizationDto.Email,
                Phone = organizationDto.Phone,
                Image = organizationDto.Image,
                AboutUsText = organizationDto.AboutUsText,
                WelcomeText = organizationDto.WelcomeText,
                FacebookUrl = organizationDto.FacebookUrl,
                InstagramUrl = organizationDto.InstagramUrl,
                LinkedinUrl = organizationDto.LinkedinUrl,
            };

            return organization;
        }

        public Organization UpdateModelWithDto(Organization model, OrganizationDTO dto)
        {
            model.Name = !ControlString(dto.Name)  ? dto.Name : model.Name;
            model.Address = !ControlString(dto.Address) ? dto.Address : model.Address;
            model.Email = !ControlString(dto.Email) ? dto.Email : model.Email;
            model.Phone = !ControlString(dto.Phone) ? dto.Phone : model.Email;
            model.Image = !ControlString(dto.Image) ? dto.Image : model.Image;
            model.AboutUsText = !ControlString(dto.AboutUsText) ? dto.AboutUsText : model.AboutUsText;
            model.WelcomeText = !ControlString(dto.WelcomeText) ? dto.WelcomeText : model.WelcomeText;
            model.FacebookUrl = !ControlString(dto.FacebookUrl) ? dto.FacebookUrl : model.FacebookUrl;
            model.LinkedinUrl = !ControlString(dto.LinkedinUrl) ? dto.LinkedinUrl : model.LinkedinUrl;
            model.InstagramUrl = !ControlString(dto.InstagramUrl) ? dto.InstagramUrl : model.InstagramUrl;

            return model;
        }

        private bool ControlString(string text)
        {
            if (text == ""  || text == "string")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
