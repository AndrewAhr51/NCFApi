using NCFApi.Domain.DTOs;

namespace NCFApi.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> UpdateUserAsync(int id, UpdateUserDto userDto);

    }
}