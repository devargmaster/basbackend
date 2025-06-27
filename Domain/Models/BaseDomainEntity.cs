namespace Domain.Models;

public abstract class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaEliminacion { get; set; }
    public bool Activo { get; set; } = true;
    public int? CreadoPor { get; set; }
    public int? ModificadoPor { get; set; }
    public int? EliminadoPor { get; set; }
}