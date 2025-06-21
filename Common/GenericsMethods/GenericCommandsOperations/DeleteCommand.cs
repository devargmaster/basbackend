using Domain.Models;
using MediatR;

namespace Common.GenericsMethods;

public class DeleteCommand<T> : IRequest<Unit> where T : BaseDomainEntity
{
    public int Id { get; }

    public DeleteCommand(int id)
    {
        Id = id;
    }
}