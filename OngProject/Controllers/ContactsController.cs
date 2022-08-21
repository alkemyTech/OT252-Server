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
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controlador para el mantenimiento de los contactos registrados de la ONG
    /// </summary>
    [SwaggerTag("Contacts", Description = "Web API para los miembros de la ONG")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactService _contactService;
        private GenericResponse _response;
        /// <summary>
        /// Constructor del controlador ContactsController
        /// </summary>
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
            _response = new GenericResponse();
        }

        /// <summary>
        /// Obtiene una lista de contactos de la ONG.
        /// </summary>
        /// <remarks>
        /// Esta api devuelve una lista con los contagtos registrados en la ONG.
        /// </remarks>       
        /// <response code="200">OK. Devuelve la lista de contactos.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>   
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAll()
        {
            try
            {
                var contactsList = await _contactService.GetAll();
                _response.DisplayMessage = "Lista de contactos";
                _response.Entity = contactsList;
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
        /// Obtiene el contacto de la ONG con el id enviado.
        /// </summary>
        /// <remarks>
        /// Esta api devuelve un contacto con el id enviado, de los contactos registrados por la ONG.
        /// </remarks>
        /// <param name="id">Id (int) de del contacto.</param>              
        /// <response code="200">OK. Devuelve el contacto con el id enviado.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>   
        /// <response code="404">NotFound. No se encontro el contacto con la id enviada.</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GenericResponse>> Get(int id)
        {
            try
            {
                var contact = await _contactService.GetById(id);
                if(contact == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = $"No se encontro el contacto con el id: {id}";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Información del contacto";
                _response.Entity = contact;
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
        /// Registra un nuevo contacto en la Base de datos de la ONG
        /// </summary>
        /// <remarks>
        /// Esta api registra un nuevo contacto, los campos Name, Phone y Email son requeridos.
        /// </remarks>
        /// <param name="contactDTO">Datos de la clase ContactDTO</param>              
        /// <response code="200">OK. Devuelve el contacto guardado.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos solicitados.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Post([FromBody] ContactDTO contactDTO)
        {
            try
            {
                var newContact = await _contactService.Insert(contactDTO);
                _response.DisplayMessage = "Se ha guardado el registro";
                _response.Entity = newContact;
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
        /// Edita un nuevo contacto en la Base de datos de la ONG
        /// </summary>
        /// <remarks>
        /// Esta api Edita un contacto ya registrado en la base de datos de la ONG, los campos Name, Phone, Email e Id son requeridos.
        /// </remarks>
        /// <param name="contactDTO">Datos de la clase ContactDTO</param>
        /// <param name="id">Id del contacto a editar</param>  
        /// <response code="200">OK. Devuelve el contacto editado.</response> 
        /// <response code="400">BadRequest. Un error al buscar los datos y editarlo solicitados.</response>   
        /// <response code="404">NotFound. No se encontro el contacto con la id enviada.</response> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ContactDTO>> Put([FromBody] ContactDTO contactDTO,int id)
        {
            try
            {
                var editContact = await _contactService.Update(contactDTO,id);
                if (editContact == null)
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = $"No se puede encontrar el contacto con el Id: {id}";
                    return NotFound(_response);
                }
                _response.DisplayMessage = "Se ha actualizado el contacto";
                _response.Entity = editContact;
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
        /// Elimina un contacto de la ONG pasando el id de la misma.
        /// </summary>
        /// <remarks>
        /// Se elimina el contacto correspondiente al id entregado.
        /// </remarks>
        /// <param name="id">Id del contacto a eliminar</param>  
        /// <response code="401">Unauthorized. El usuario no se ha autentificado o no tiene perfil de administrador.</response>
        /// <response code="200">Ok. Retorna true si se elimino correctamente el registro.</response>
        /// <response code="400">BadRequest. Devuelve el error ocurrido en caso de que la operación no se realice.</response>
        /// <response code="404">NotFound. El contacto no existe o no se encontro.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var deleteContact = _contactService.Delete(id);
                if (deleteContact.Result)
                {
                    _response.DisplayMessage = "Se ha eliminado el contacto";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSucces = false;
                    _response.DisplayMessage = $"No se encontro el id {id} para eliminar";
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
    }
}
