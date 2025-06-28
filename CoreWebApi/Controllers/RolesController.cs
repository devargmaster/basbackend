using Common;
using Domain.Models.Entities;
using MediatR;

namespace CoreWebApi.Controllers
{
    public class RolesController : BaseController<Roles>
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
