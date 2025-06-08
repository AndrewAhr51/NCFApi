using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Security.Cryptography;

namespace NCFApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // ✅ Create a new user
        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var hashedPassword = HashPassword(userDto.Password);
            var roleId = await GetRoleId(userDto.Role);

            var newUser = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                RoleId = roleId
            };

            var createdUser = await _userRepository.AddAsync(newUser);
            return new UserDto { Id = createdUser.Id, Username = createdUser.Username, Email = createdUser.Email, Role = createdUser.RoleId };
        }

        // ✅ Retrieve a user by ID
        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDto { Id = user.Id, Username = user.Username, Email = user.Email, Role = user.RoleId };
        }

        // ✅ Update user details
        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            user.Username = userDto.Username;
            user.Email = userDto.Email;

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.PasswordHash = HashPassword(userDto.Password);
            }

            return await _userRepository.UpdateAsync(user);
        }

        // ✅ Delete a user by ID
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        private async Task<int> GetRoleId(string role)
        {
            return await _userRepository.GetRoleIdAsync(role);
        }
    }
}