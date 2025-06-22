using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models;
using Infraestructure.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers;

/// <summary>
/// Generic handler for retrieving an entity by its identifier.
/// </summary>
public class GetByIdHandler<T> : IRequestHandler<GetByIdQuery<T>, GetByIdResponse<T>> where T : BaseDomainEntity
{
    private readonly IRepository _repository;

    public GetByIdHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdResponse<T>> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync<T>(request.Id);
        return  entity != null 
            ? new GetByIdResponse<T>(entity) 
            : null;
    }
}
