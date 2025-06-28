using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.Stock;

public class StockCreateHandler : CreateHandler<Domain.Models.Entities.Stock>, IRequestHandler<CreateCommand<Domain.Models.Entities.Stock>, CreateResponse<Domain.Models.Entities.Stock>>
{
    public StockCreateHandler(IRepository repository) : base(repository) { }
}
