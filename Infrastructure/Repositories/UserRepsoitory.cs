using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Data;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Create a new user
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // ✅ Retrieve a user by ID
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // ✅ Retrieve a user by username
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        // ✅ Update user details
        public async Task<bool> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        // ✅ Remove a user by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }

        // ✅ Retrieve role ID by role name
        public async Task<int> GetRoleIdAsync(string role)
        {
            return await _context.Roles
                .Where(r => r.Name == role)
                .Select(r => r.RoleId)
                .FirstOrDefaultAsync();
        }
    }
}