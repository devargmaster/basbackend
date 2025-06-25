using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Common.GenericsMethods;
using Common.GenericsMethods.Queries;
using Domain.Models;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;
using Common.GenericsMethods.GenericCommandsOperations;
using Microsoft.EntityFrameworkCore;

namespace Common;

  [ApiController]
  [Route("api/[controller]")]
public class BaseController<T> : ControllerBase where T: BaseDomainEntity
{
    // utilizo mediator
    private readonly IMediator _mediator;
    

    public BaseController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<T>>> Get()
    {
        var response = await _mediator.Send(new GetQuery<T>());
        if (response.Data == null)
        {
            return NotFound();
        }
        return Ok(response.Data.ToList());
    }
    [HttpGet("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<T>> GetById([FromRoute] int id)
    {

        var response = await _mediator.Send(new GetByIdQuery<T>(id));
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Create([FromBody] T entityToCreate)
    {
        var response = await _mediator.Send(new CreateCommand<T>(entityToCreate));
        return Ok(response);
    }
    [HttpPut("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<T>> Update([FromRoute] int id, [FromBody] T entityToUpdate)
    {
        if (id != entityToUpdate.Id)
        {
            return BadRequest();
        }

        var response = await _mediator.Send(new UpdateCommand<T>(entityToUpdate));
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteCommand<T>(id));
            return Ok(result);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
        {
            return BadRequest(new
            {
                message = "No se puede eliminar el usuario porque tiene productos asociados. Elimine primero los productos relacionados antes de eliminar el usuario."
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor.", detail = ex.Message });
        }
    }
}