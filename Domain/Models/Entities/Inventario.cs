using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;


[Obsolete("Usar MovimientosInventario y Stock en su lugar")]
public class Inventario : BaseDomainEntity
{
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }
    
    public int Cantidad { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaSalida { get; set; }
    
    [MaxLength(500)]
    public string? Observaciones { get; set; }
    
    public int UsuarioId { get; set; }
    public Usuarios? Usuario { get; set; }
}
