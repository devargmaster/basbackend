using Common;
using CoreWebApi.Models.Entities;
using MediatR;

namespace CoreWebApi.Controllers;

public class PermissionsTypeController : BaseController<PermissionsType>
{
    public PermissionsTypeController(IMediator mediator) : base(mediator)
    {
    }
}