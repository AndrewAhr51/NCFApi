using Microsoft.AspNetCore.Mvc;
using NCFApi.Application.DTOs;
using NCFApi.Application.Services;

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
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _authService.AuthenticateAsync(loginDto);
        if (token == null)
            return Unauthorized("Invalid username or password.");

        return Ok(new { Token = token });
    }
}