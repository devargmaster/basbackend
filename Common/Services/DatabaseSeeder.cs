using Domain.Models.Entities;
using Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {

        if (await context.Set<Usuarios>().AnyAsync())
        {
            return; 
        }


        var usuarios = new List<Usuarios>
        {
            new Usuarios
            {
                Nombre = "Administrador",
                Apellido = "Sistema",
                UserName = "admin",
                Password = "admin123",
                Email = "admin@bas.com",
                Activo = true
            },
            new Usuarios
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                UserName = "jperez",
                Password = "juan123",
                Email = "juan.perez@bas.com",
                Activo = true
            },
            new Usuarios
            {
                Nombre = "María",
                Apellido = "García",
                UserName = "mgarcia",
                Password = "maria123",
                Email = "maria.garcia@bas.com",
                Activo = true
            }
        };

        context.Set<Usuarios>().AddRange(usuarios);
        await context.SaveChangesAsync();
        
        Console.WriteLine("Usuarios de prueba creados:");
        Console.WriteLine("- admin / admin123 (Administrador)");
        Console.WriteLine("- jperez / juan123 (Juan Pérez)");
        Console.WriteLine("- mgarcia / maria123 (María García)");
    }
}
