using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Roles;

public class RolesGetHandler : GetHandler<Domain.Models.Entities.Roles>, IRequestHandler<GetQuery<Domain.Models.Entities.Roles>, GetResponse<Domain.Models.Entities.Roles>>
{
    public RolesGetHandler(IRepository repository) : base(repository) { }
}
