using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Stock;

public class StockDeleteHandler : DeleteHandler<Domain.Models.Entities.Stock>, IRequestHandler<DeleteCommand<Domain.Models.Entities.Stock>, Unit>
{
    public StockDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}
