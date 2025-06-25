using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers;

public class InventarioGetHandler : GetHandler<Domain.Models.Entities.Inventario>, IRequestHandler<GetQuery<Domain.Models.Entities.Inventario>, GetResponse<Domain.Models.Entities.Inventario>>
{
    public InventarioGetHandler(IRepository repository) : base(repository) { }
}
