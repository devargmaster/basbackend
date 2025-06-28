using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Stock;

public class StockUpdateHandler : UpdateHandler<Domain.Models.Entities.Stock>, IRequestHandler<UpdateCommand<Domain.Models.Entities.Stock>, Unit>
{
    public StockUpdateHandler(IRepository repository) : base(repository) { }
}
