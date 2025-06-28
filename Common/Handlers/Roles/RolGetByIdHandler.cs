using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Roles;

public class RolGetByIdHandler : GetByIdHandler<Domain.Models.Entities.Roles>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.Roles>, GetByIdResponse<Domain.Models.Entities.Roles>>
{
    public RolGetByIdHandler(IRepository repository) : base(repository) { }
}
