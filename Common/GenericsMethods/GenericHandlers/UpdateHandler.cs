
using Domain.Models;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.GenericsMethods.GenericHandlers;

/// <summary>
/// Generic handler for updating an entity.
/// </summary>
public class UpdateHandler<T> : IRequestHandler<UpdateCommand<T>, Unit> where T : BaseDomainEntity
{
    private readonly IRepository _repository;

    public UpdateHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.EntityToUpdate);
        return Unit.Value;
    }
}
