using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.Inventario;

public class InventariosCreateHandler : CreateHandler<Domain.Models.Entities.Inventario>, IRequestHandler<CreateCommand<Domain.Models.Entities.Inventario>, CreateResponse<Domain.Models.Entities.Inventario>>
{
    public InventariosCreateHandler(IRepository repository) : base(repository) { }
}