using NCFApi.Domain.DTOs;

namespace NCFApi.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<UserDto?> GetUserByIdAsync(int id);
    }
}