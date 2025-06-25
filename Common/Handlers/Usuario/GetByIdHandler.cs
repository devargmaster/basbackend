using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Usuario.Handlers;

public class GetByIdHandler : GetByIdHandler<Usuarios>, IRequestHandler<GetByIdQuery<Usuarios>, GetByIdResponse<Usuarios>>
{
    public GetByIdHandler(IRepository repository) : base(repository) { }
}