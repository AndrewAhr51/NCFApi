using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var hashedPassword = HashPassword(userDto.Password);

            var newUser = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                Role = userDto.Role
            };

            var createdUser = await _userRepository.AddAsync(newUser);
            return new UserDto { Id = createdUser.Id, Username = createdUser.Username, Email = createdUser.Email, Role = createdUser.Role };
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDto { Id = user.Id, Username = user.Username, Email = user.Email, Role = user.Role };
        }

        private string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32
            ));
        }
    }
}