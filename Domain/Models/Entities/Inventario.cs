using System;

namespace Domain.Models.Entities;

public class Inventario : BaseDomainEntity
{
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaSalida { get; set; }
    public string? Observaciones { get; set; }
    public bool Activo { get; set; } = true; 
    public DateTime Creado { get; set; } = DateTime.UtcNow; 
    public DateTime? Modificado { get; set; } 
    public DateTime? Eliminado { get; set; } 
    public DateTime? FechaUltimoMovimiento { get; set; }
    public int UsuarioId { get; set; }
    public Usuarios? Usuario { get; set; }
}
