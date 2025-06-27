using Domain.Models.Entities;
using Infraestructure.Contexts;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Asegurarse de que la base de datos existe
        await context.Database.EnsureCreatedAsync();

        // Aplicar migraciones pendientes
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }

        // Seed de usuarios
        await UserSeeder.SeedUsersAsync(context);

        // Seed de productos y stock
        await UserSeeder.SeedProductsAndStockAsync(context);
        
        Console.WriteLine("Base de datos inicializada con datos de prueba.");
    }
}
