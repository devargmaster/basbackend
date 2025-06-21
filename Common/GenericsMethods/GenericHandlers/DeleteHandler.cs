using Domain.Models;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.GenericsMethods.GenericHandlers;

public class DeleteHandler<T> : IRequestHandler<DeleteCommand<T>, Unit> where T : BaseDomainEntity
{
    private readonly IRepository _repository;

    public DeleteHandler(IRepositoryFactory repositoryFactory)
    {
        _repository = repositoryFactory.CreateRepository<T>();
    }
    
    public async Task<Unit> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.DeleteAsync<T>(request.Id);
        return Unit.Value;
    }
}