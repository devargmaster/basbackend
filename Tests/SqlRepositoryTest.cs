using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Contexts;
using Infraestructure.Repositories;
using Domain.Models.Entities;
using Microsoft.Extensions.Logging.Abstractions;

public class SqlRepositoryTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateAndGetById_Works()
    {
        using var context = CreateContext();
        var repo = new SqlRepository(context, NullLogger<SqlRepository>.Instance);

        var producto = new Productos { Nombre = "Filamento", Descripcion = "Filamento PLA", Precio = 10m };
        await repo.CreateAsync(producto);

        var result = await repo.GetByIdAsync<Productos>(producto.Id);

        Assert.Equal("Filamento", result.Nombre);
        Assert.Equal(10m, result.Precio);
    }

    [Fact]
    public async Task Update_ChangesPersisted()
    {
        using var context = CreateContext();
        var repo = new SqlRepository(context, NullLogger<SqlRepository>.Instance);

        var producto = new Productos { Nombre = "PETG", Descripcion = "PETG", Precio = 10m };
        await repo.CreateAsync(producto);

        producto.Nombre = "Updated";
        await repo.UpdateAsync(producto);

        var result = await repo.GetByIdAsync<Productos>(producto.Id);
        Assert.Equal("Updated", result.Nombre);
    }

    [Fact]
    public async Task Delete_RemovesEntity()
    {
        using var context = CreateContext();
        var repo = new SqlRepository(context, NullLogger<SqlRepository>.Instance);

        var producto = new Productos { Nombre = "Item1", Descripcion = "Desc", Precio = 10m };
        await repo.CreateAsync(producto);

        await repo.DeleteAsync<Productos>(producto.Id);

        await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            await repo.GetByIdAsync<Productos>(producto.Id));
    }
}