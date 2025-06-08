using NCFApi.Application.DTOs;

namespace NCFApi.Application.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(LoginDto loginDto);
    }
}