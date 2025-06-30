using Common;
using Common.Services;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers;

public class AuthController : BaseController<Usuarios>
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService, IMediator mediator) : base(mediator)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Usuario y contraseña son requeridos" });
            }

            var result = await _authService.LoginAsync(request);
            
            if (result == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", detail = ex.Message });
        }
    }

    [HttpPost("validate")]
    public async Task<IActionResult> ValidateToken([FromBody] ValidateTokenRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Token))
            {
                return BadRequest(new { message = "Token es requerido" });
            }

            var user = await _authService.ValidateTokenAsync(request.Token);
            
            if (user == null)
            {
                return Unauthorized(new { message = "Token inválido o expirado" });
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", detail = ex.Message });
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok(new { message = "Sesión cerrada exitosamente" });
    }
}
