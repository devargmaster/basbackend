using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Roles;

public class RolUpdateHandler : UpdateHandler<Domain.Models.Entities.Roles>, IRequestHandler<UpdateCommand<Domain.Models.Entities.Roles>, Unit>
{
    public RolUpdateHandler(IRepository repository) : base(repository) { }
}
