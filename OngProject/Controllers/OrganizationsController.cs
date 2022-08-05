using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {

        private readonly IOrganizationsService _organizationsService;

        public OrganizationsController(IOrganizationsService organizationsService)
        {
            _organizationsService = organizationsService;
        }

        [Route("public")]
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<OrganizationDTO>>> GetAll()
        {

            try
            {
                var organizationList = await _organizationsService.GetAll();

                return Ok(organizationList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<OrganizationDTO>> Get(int id)
        {
            try
            {
                var organization = await _organizationsService.GetById(id);
                if (organization != null)
                {
                    return Ok(organization);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult<News> Post([FromBody] Organization organization)
        {
            try
            {
                var newOrganization = _organizationsService.Insert(organization);

                return Ok(newOrganization);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("public")]
        //[Authorize(Roles = "Administrador")]
        public async Task<ActionResult<OrganizationDTO>> Put([FromBody] OrganizationDTO organization, int id)
        {
            try
            {
                var org = await _organizationsService.Update(organization, id);
                if (org != null)
                {
                    return Ok(org);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var deleteOrganization = _organizationsService.Delete(id);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
