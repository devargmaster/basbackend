using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Roles;

public class RolDeleteHandler : DeleteHandler<Domain.Models.Entities.Roles>, IRequestHandler<DeleteCommand<Domain.Models.Entities.Roles>, Unit>
{
    public RolDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}
