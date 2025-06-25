using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers;

public class InventarioGetByIdHandler : GetByIdHandler<Domain.Models.Entities.Inventario>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.Inventario>, GetByIdResponse<Domain.Models.Entities.Inventario>>
{
    public InventarioGetByIdHandler(IRepository repository) : base(repository) { }
}