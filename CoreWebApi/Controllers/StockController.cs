using Common;
using Domain.Models.Entities;
using MediatR;

namespace CoreWebApi.Controllers
{
    public class StockController : BaseController<Stock>
    {
        public StockController(IMediator mediator) : base(mediator)
        {
        }
    }
}
