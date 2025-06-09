using Microsoft.AspNetCore.Mvc;
using NCFApi.Application.Services;
using NCFApi.Domain.DTOs;
using System.Threading.Tasks;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _authService.AuthenticateAsync(request);
        return token != null ? Ok(new { Token = token }) : Unauthorized();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var newToken = await _authService.RefreshTokenAsync(request.ExpiredToken);
        return newToken != null ? Ok(new { Token = newToken }) : Unauthorized();
    }
}