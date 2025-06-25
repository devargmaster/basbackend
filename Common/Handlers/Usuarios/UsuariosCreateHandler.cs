using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.Usuarios;

public class UsuariosCreateHandler : CreateHandler<Domain.Models.Entities.Usuarios>, IRequestHandler<CreateCommand<Domain.Models.Entities.Usuarios>, CreateResponse<Domain.Models.Entities.Usuarios>>
{
    public   UsuariosCreateHandler(IRepository repository) : base(repository) { }
}