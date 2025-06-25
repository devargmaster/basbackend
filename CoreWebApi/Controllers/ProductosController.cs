using Common;
using Domain.Models.Entities;
using MediatR;


namespace CoreWebApi.Controllers
{
    public class ProductosController : BaseController<Productos>
    {
        public ProductosController(IMediator mediator) : base(mediator)
        {
        }
    }
    
}