using NCFApi.Domain.DTOs;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(LoginDto loginDto);
        Task<string?> RefreshTokenAsync(string expiredToken); // ✅ Supports secure token renewal
    }
}