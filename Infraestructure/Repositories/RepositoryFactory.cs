using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Repositories;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly IServiceProvider serviceProvider;
    
    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    public IRepository CreateRepository<T>() where T : BaseDomainEntity
    {
        // aca yo le puse repositorio de sql, pero se puede cambiar
        // por otro repositorio, como uno de mongo, o de otro tipo
        return serviceProvider.GetRequiredService<SqlRepository>();
    }

}