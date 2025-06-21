using Common;
using Domain.Models.Entities;
using MediatR;


namespace CoreWebApi.Controllers
{
    public class UsuariosController : BaseController<Usuarios>
    {
        public UsuariosController(IMediator mediator) : base(mediator)
        {
        }
    }
    
}
