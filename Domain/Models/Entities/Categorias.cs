using Domain.Models;
using System.Collections.Generic;

namespace Domain.Models.Entities;

public class Categorias : BaseDomainEntity
{
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool Activo { get; set; } = true;
    public ICollection<Productos> Productos { get; set; } = new List<Productos>();
}