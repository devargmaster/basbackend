using Common.GenericsMethods;
using Common.GenericsMethods.GenericCommandsOperations;
using Common.GenericsMethods.GenericHandlers;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Usuarios;

public class UsuariosUpdateHandler : UpdateHandler<Domain.Models.Entities.Usuarios>, IRequestHandler<UpdateCommand<Domain.Models.Entities.Usuarios>, Unit>
{
    public UsuariosUpdateHandler(IRepository repository) : base(repository) { }
}
