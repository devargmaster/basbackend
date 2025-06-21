using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models;
using Infraestructure.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers;

/// <summary>
/// Generic handler for retrieving all entities of a given type.
/// </summary>
public class GetHandler<T> : IRequestHandler<GetQuery<T>, GetResponse<T>> where T : BaseDomainEntity
{
    private readonly IRepository _repository;

    public GetHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse<T>> Handle(GetQuery<T> request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAsync<T>();
        return new GetResponse<T>(entities);
    }
}
