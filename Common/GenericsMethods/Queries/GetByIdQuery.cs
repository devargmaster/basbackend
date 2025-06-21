using Common.GenericsMethods.GenericResponse;
using Domain.Models;
using MediatR;

namespace Common.GenericsMethods.Queries;

public class GetByIdQuery<T> : IRequest<GetByIdResponse<T>> where T : BaseDomainEntity
{
    public int Id { get; }

    public GetByIdQuery(int id)
    {
        Id = id;
    }
}