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
        return  serviceProvider.GetRequiredService<SqlRepository>();
    }

}