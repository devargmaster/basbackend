namespace Domain.Models.DTOs;

public class LoginRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}

public class LoginResponse
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string UserName { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public required string Token { get; set; }
    public DateTime LoginTime { get; set; } = DateTime.UtcNow;
    public RolInfo? Rol { get; set; }
}

public class RolInfo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool PuedeGestionarUsuarios { get; set; }
    public bool PuedeGestionarProductos { get; set; }
    public bool PuedeGestionarInventario { get; set; }
    public bool PuedeVerReportes { get; set; }
    public bool EsAdministrador { get; set; }
}

public class AuthUser
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string UserName { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public RolInfo? Rol { get; set; }
    public DateTime? UltimoAcceso { get; set; }
    public bool Activo { get; set; }
}

public class ValidateTokenRequest
{
    public required string Token { get; set; }
}

// DTOs para gestión de usuarios
public class UsuarioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int? RolId { get; set; }
    public RolInfo? Rol { get; set; }
    public DateTime? UltimoAcceso { get; set; }
    public int IntentosLoginFallidos { get; set; }
    public DateTime? FechaBloqueado { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
}

public class CreateUsuarioDto
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int? RolId { get; set; }
}

public class UpdateUsuarioDto
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int? RolId { get; set; }
    public bool? Activo { get; set; }
}

public class ChangePasswordDto
{
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
}
