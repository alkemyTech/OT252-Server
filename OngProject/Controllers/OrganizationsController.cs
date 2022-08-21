using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de las organizaciones de la ONG
    /// </summary>
    [SwaggerTag("Organizations", Description = "Web API de las Organizaciones de la ONG")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {

        private readonly IOrganizationsService _organizationsService;
        private readonly GenericResponse _response;

        public OrganizationsController(IOrganizationsService organizationsService)
        {
            _organizationsService = organizationsService;
            _response = new GenericResponse();
        }

        /// <summary>
        /// Obtiene todas las organizaciones de la ONG.
        /// </summary>
        /// <remarks>
        /// Retorna un listado con todas las organizaciones de la ONG.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un listado de todas las organizaciones.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("public")]
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<OrganizationDTO>>> GetAll()
        {

            try
            {
                var organizationList = await _organizationsService.GetAll();
                _response.DisplayMessage = "Lista de organizaciones";
                _response.Entity = organizationList;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }


        }

        /// <summary>
        /// Obtiene una organización de la ONG con el id pasado por parámetro.
        /// </summary>
        /// <remarks>
        /// Retorna una organización.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve la información de la organización.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de error en caso de que el id no corresponda a una organización registrada.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<OrganizationDTO>> Get(int id)
        {
            try
            {
                var organization = await _organizationsService.GetById(id);
                if (organization != null)
                {
                    _response.DisplayMessage = "Información de la organización";
                    _response.Entity = organization;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "La organización no existe";
                    return NotFound(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }

        }

        /*
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        */

        /// <summary>
        /// Actualiza la información de la organización pasando el id de la misma.
        /// </summary>
        /// <remarks>
        /// Para actualizar la organización se debe ingresar los campos requeridos*.
        /// </remarks>
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Devuelve un mensaje de éxito de la operación y la información de la organización modificada.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. Devuelve un mensaje de registro no esta registrado si el id de la organización no corresponde a un registro.</response>
        /// <response code="500">InternalServerError. Devuelve el error que impide que la operación se realice.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Route("public")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<OrganizationDTO>> Put([FromBody] OrganizationDTO organization, int id)
        {
            try
            {
                var org = await _organizationsService.Update(organization, id);
                if (org != null)
                {
                    _response.DisplayMessage = "Se ha actualizado la información";
                    _response.Entity = org;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = "La Organización no existe";
                    return NotFound(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { "Ha ocurrido un error", ex.ToString() };
                return BadRequest(_response);
            }

        }

        /*
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        */
    }
}
