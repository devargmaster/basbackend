using Domain.Models.Entities;
using Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public static class UserSeeder
{
    public static async Task SeedUsersAsync(AppDbContext context)
    {
        // Verificar si ya existen usuarios
        if (await context.Usuarios.AnyAsync())
        {
            return; // Ya hay usuarios
        }

        // Obtener roles
        var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Administrador");
        var gerenteRole = await context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Gerente");
        var empleadoRole = await context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Empleado");

        // Crear usuarios de prueba
        var usuarios = new List<Usuarios>
        {
            new Usuarios
            {
                Nombre = "Walter",
                Apellido = "Rodriguez",
                UserName = "warce",
                Password = "admin123", // En producción esto debería estar hasheado
                Email = "walter@bas.com",
                RolId = adminRole?.Id,
                Activo = true,
                FechaCreacion = DateTime.UtcNow,
                IntentosLoginFallidos = 0
            },
            new Usuarios
            {
                Nombre = "Ana",
                Apellido = "García",
                UserName = "ana.garcia",
                Password = "gerente123",
                Email = "ana@bas.com",
                RolId = gerenteRole?.Id,
                Activo = true,
                FechaCreacion = DateTime.UtcNow,
                IntentosLoginFallidos = 0
            },
            new Usuarios
            {
                Nombre = "Carlos",
                Apellido = "López",
                UserName = "carlos.lopez",
                Password = "empleado123",
                Email = "carlos@bas.com",
                RolId = empleadoRole?.Id,
                Activo = true,
                FechaCreacion = DateTime.UtcNow,
                IntentosLoginFallidos = 0
            }
        };

        context.Usuarios.AddRange(usuarios);
        await context.SaveChangesAsync();
    }

    public static async Task SeedProductsAndStockAsync(AppDbContext context)
    {
        // Verificar si ya existen productos
        if (await context.Productos.AnyAsync())
        {
            return; // Ya hay productos
        }

        // Obtener categorías
        var electronicosCategory = await context.Categorias.FirstOrDefaultAsync(c => c.Nombre == "Electrónicos");
        var oficinaCategory = await context.Categorias.FirstOrDefaultAsync(c => c.Nombre == "Oficina");
        var herramientasCategory = await context.Categorias.FirstOrDefaultAsync(c => c.Nombre == "Herramientas");

        // Crear productos de ejemplo
        var productos = new List<Productos>
        {
            new Productos
            {
                Nombre = "Laptop Dell Inspiron",
                Descripcion = "Laptop Dell Inspiron 15 con procesador Intel i5",
                Precio = 15000.00m,
                CategoriaId = electronicosCategory?.Id,
                Marca = "Dell",
                CodigoBarras = "7501234567890",
                UnidadMedida = "Pieza",
                Proveedor = "Dell México",
                PrecioCompra = 12000.00m,
                IVA = 0.16m,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            },
            new Productos
            {
                Nombre = "Mouse Inalámbrico",
                Descripcion = "Mouse inalámbrico ergonómico con sensor óptico",
                Precio = 350.00m,
                CategoriaId = electronicosCategory?.Id,
                Marca = "Logitech",
                CodigoBarras = "7501234567891",
                UnidadMedida = "Pieza",
                Proveedor = "Logitech México",
                PrecioCompra = 250.00m,
                IVA = 0.16m,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            },
            new Productos
            {
                Nombre = "Resma de Papel A4",
                Descripcion = "Resma de papel bond blanco tamaño carta",
                Precio = 120.00m,
                CategoriaId = oficinaCategory?.Id,
                Marca = "Scribe",
                CodigoBarras = "7501234567892",
                UnidadMedida = "Resma",
                Proveedor = "Papelería Central",
                PrecioCompra = 90.00m,
                IVA = 0.16m,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            },
            new Productos
            {
                Nombre = "Taladro Eléctrico",
                Descripcion = "Taladro eléctrico de 1/2 pulgada con velocidad variable",
                Precio = 1200.00m,
                CategoriaId = herramientasCategory?.Id,
                Marca = "Black & Decker",
                CodigoBarras = "7501234567893",
                UnidadMedida = "Pieza",
                Proveedor = "Ferretería Industrial",
                PrecioCompra = 900.00m,
                IVA = 0.16m,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            }
        };

        context.Productos.AddRange(productos);
        await context.SaveChangesAsync();

        // Crear stock para cada producto
        var stocks = new List<Stock>();
        foreach (var producto in productos)
        {
            stocks.Add(new Stock
            {
                ProductoId = producto.Id,
                CantidadActual = Random.Shared.Next(10, 100),
                CantidadReservada = 0,
                StockMinimo = 5,
                StockMaximo = 200,
                Ubicacion = $"Almacén A-{Random.Shared.Next(1, 20):D2}",
                CostoUnitarioPromedio = producto.PrecioCompra ?? 0,
                RequiereReconteo = false,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            });
        }

        context.Stock.AddRange(stocks);
        await context.SaveChangesAsync();
    }
}
