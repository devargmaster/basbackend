using Common;
using Domain.Models.Entities;
using MediatR;


namespace CoreWebApi.Controllers
{
    public class InventarioController : BaseController<Inventario>
    {
        public InventarioController(IMediator mediator) : base(mediator)
        {
        }
    }
    
}