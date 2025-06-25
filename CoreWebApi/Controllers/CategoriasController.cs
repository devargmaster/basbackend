using Common;
using Domain.Models.Entities;
using MediatR;


namespace CoreWebApi.Controllers
{
    public class CategoriasController : BaseController<Categorias>
    {
        public CategoriasController(IMediator mediator) : base(mediator)
        {
        }
    }
    
}
