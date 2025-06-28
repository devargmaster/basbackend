using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Stock;

public class StockGetHandler : GetHandler<Domain.Models.Entities.Stock>, IRequestHandler<GetQuery<Domain.Models.Entities.Stock>, GetResponse<Domain.Models.Entities.Stock>>
{
    public StockGetHandler(IRepository repository) : base(repository) { }
}
