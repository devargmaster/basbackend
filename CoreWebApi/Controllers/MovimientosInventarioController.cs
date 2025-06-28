using Common;
using Domain.Models.Entities;
using MediatR;

namespace CoreWebApi.Controllers
{
    public class MovimientosInventarioController : BaseController<MovimientosInventario>
    {
        public MovimientosInventarioController(IMediator mediator) : base(mediator)
        {
        }
    }
}
