using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Common.Services;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request);
    Task<AuthUser?> ValidateTokenAsync(string token);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}

public class AuthService : IAuthService
{
    private readonly IRepository _repository;
    private readonly string _secretKey = "BAS-Challenge-Secret-Key-2025-Very-Secure";

    public AuthService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        try
        {
            // Buscar usuario por UserName
            var usuarios = await _repository.GetAsync<Usuarios>();
            var usuario = usuarios.FirstOrDefault(u => 
                u.UserName == request.UserName && u.Activo);

            if (usuario == null)
                return null;


            if (usuario.Password != request.Password)
                return null;


            var token = GenerateSimpleToken(usuario);

            return new LoginResponse
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                UserName = usuario.UserName,
                Email = usuario.Email,
                Token = token
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<AuthUser?> ValidateTokenAsync(string token)
    {
        try
        {

            var userId = DecodeSimpleToken(token);
            if (userId == null) return null;

            var usuarios = await _repository.GetAsync<Usuarios>();
            var usuario = usuarios.FirstOrDefault(u => u.Id == userId && u.Activo);

            if (usuario == null) return null;

            return new AuthUser
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                UserName = usuario.UserName,
                Email = usuario.Email
            };
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + _secretKey));
        return Convert.ToBase64String(hashedBytes);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var hashToVerify = HashPassword(password);
        return hashToVerify == hashedPassword;
    }

    private string GenerateSimpleToken(Usuarios usuario)
    {

        var tokenData = $"{usuario.Id}:{usuario.UserName}:{DateTime.UtcNow.Ticks}";
        var tokenBytes = Encoding.UTF8.GetBytes(tokenData);
        return Convert.ToBase64String(tokenBytes);
    }

    private int? DecodeSimpleToken(string token)
    {
        try
        {
            var tokenBytes = Convert.FromBase64String(token);
            var tokenData = Encoding.UTF8.GetString(tokenBytes);
            var parts = tokenData.Split(':');
            
            if (parts.Length >= 3 && int.TryParse(parts[0], out var userId))
            {
                // Verificar que el token no sea muy viejo (24 horas)
                if (long.TryParse(parts[2], out var ticks))
                {
                    var tokenTime = new DateTime(ticks);
                    if (DateTime.UtcNow.Subtract(tokenTime).TotalHours < 24)
                    {
                        return userId;
                    }
                }
            }
            
            return null;
        }
        catch
        {
            return null;
        }
    }
}
