using System;
using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Usuarios;

public class UsuariosGetHandler : GetHandler<Domain.Models.Entities.Usuarios>, IRequestHandler<GetQuery<Domain.Models.Entities.Usuarios>, GetResponse<Domain.Models.Entities.Usuarios>>
{
    public UsuariosGetHandler(IRepository repository) : base(repository) { }

}
