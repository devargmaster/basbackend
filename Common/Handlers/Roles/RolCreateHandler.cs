using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.Roles;

public class RolCreateHandler : CreateHandler<Domain.Models.Entities.Roles>, IRequestHandler<CreateCommand<Domain.Models.Entities.Roles>, CreateResponse<Domain.Models.Entities.Roles>>
{
    public RolCreateHandler(IRepository repository) : base(repository) { }
}
