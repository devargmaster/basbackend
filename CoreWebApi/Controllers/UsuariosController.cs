using Common;
using Domain.Models.Entities;
using Domain.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Common.GenericsMethods.Queries;
using Common.GenericsMethods;
using Common.GenericsMethods.GenericCommandsOperations;

namespace CoreWebApi.Controllers
{
    public class UsuariosController : BaseController<Usuarios>
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Usuarios>> UpdateUsuario(int id, [FromBody] UpdateUsuarioDto updateDto)
        {
            var existingUserResponse = await _mediator.Send(new GetByIdQuery<Usuarios>(id));
            if (existingUserResponse?.Entity == null)
                return NotFound();

            var user = existingUserResponse.Entity;

            if (!string.IsNullOrEmpty(updateDto.Nombre))
                user.Nombre = updateDto.Nombre;
            
            if (!string.IsNullOrEmpty(updateDto.Apellido))
                user.Apellido = updateDto.Apellido;
            
            if (!string.IsNullOrEmpty(updateDto.UserName))
                user.UserName = updateDto.UserName;
            
            user.Email = updateDto.Email;
            user.Telefono = updateDto.Telefono;
            
            if (updateDto.RolId.HasValue)
                user.RolId = updateDto.RolId;
            
            if (updateDto.Activo.HasValue)
                user.Activo = updateDto.Activo.Value;

            user.FechaModificacion = DateTime.UtcNow;

            await _mediator.Send(new UpdateCommand<Usuarios>(user));
            return Ok(user);
        }
    }
}
