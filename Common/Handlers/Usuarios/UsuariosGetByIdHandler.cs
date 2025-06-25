using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Usuarios;

public class UsuariosGetByIdHandler : GetByIdHandler<Domain.Models.Entities.Usuarios>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.Usuarios>, GetByIdResponse<Domain.Models.Entities.Usuarios>>
{
    public UsuariosGetByIdHandler(IRepository repository) : base(repository) { }
}