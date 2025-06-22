using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers;

public class UsuariosCreateHandler : CreateHandler<Usuarios>, IRequestHandler<CreateCommand<Usuarios>, CreateResponse<Usuarios>>
{
    public UsuariosCreateHandler(IRepository repository) : base(repository) { }
}