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
    public required string Token { get; set; }
    public DateTime LoginTime { get; set; } = DateTime.UtcNow;
}

public class AuthUser
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string UserName { get; set; }
    public string? Email { get; set; }
}

public class ValidateTokenRequest
{
    public required string Token { get; set; }
}
