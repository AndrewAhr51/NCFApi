using System.Threading.Tasks;
using NCFApi.Domain.Entities;

namespace NCFApi.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);  // ✅ Create a new user
        Task<User?> GetByIdAsync(int id);  // ✅ Retrieve a user by ID
        Task<User?> GetByUsernameAsync(string username);  // ✅ Retrieve a user by username
        Task<bool> UpdateAsync(User user);  // ✅ Update user details
        Task<bool> DeleteAsync(int id);  // ✅ Remove a user by ID
    }
}