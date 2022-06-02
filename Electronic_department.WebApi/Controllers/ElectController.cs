using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Electronic_department.Application.Electronic_department.Queries.GetElectList;
using Electronic_department.Application.Electronic_department.Queries.GetElectDetails;
using Electronic_department.Application.Electronic_department.Commands.UpdateElect;
using Electronic_department.Application.Electronic_department.Commands.DeleteCommand;
using Electronic_department.WebApi.Models;
using NoteElectronic_department.Application.Electronic_department.Queries.GetElectList;
using Electronic_department.Application.Electronic_department.Commands.CreateNote;
using Electronic_department.Application.Electronic_department.Commands.UpdateNote;

namespace Electronic_department.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ElectController : BaseController
    {
        private readonly IMapper _mapper;

        public ElectController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns ElectListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ElectListVm>> GetAll()
        {
            var query = new GetElectListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /elect/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Elect id (guid)</param>
        /// <returns>Returns ElectDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ElectDetailsVm>> Get(Guid id)
        {
            var query = new GetElectDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /elect
        /// {
        ///     title: "elect title",
        ///     details: "elect details"
        /// }
        /// </remarks>
        /// <param name="createElectDto">CreateElectDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateElectDto createElectDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createElectDto);
            command.UserId = UserId;
            var electId = await Mediator.Send(command);
            return Ok(electId);
        }

        /// <summary>
        /// Updates the elect
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /elect
        /// {
        ///     title: "updated elect title"
        /// }
        /// </remarks>
        /// <param name="updateNoteDto">UpdateElectDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateElectDto updateElectDto)
        {
            var command = _mapper.Map<UpdateElectCommand>(updateElectDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the elect by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /elect/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the elect (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteElectCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
