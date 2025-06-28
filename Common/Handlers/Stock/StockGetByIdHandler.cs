using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Stock;

public class StockGetByIdHandler : GetByIdHandler<Domain.Models.Entities.Stock>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.Stock>, GetByIdResponse<Domain.Models.Entities.Stock>>
{
    public StockGetByIdHandler(IRepository repository) : base(repository) { }
}
