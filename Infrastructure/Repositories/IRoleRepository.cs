using NCFApi.Domain.Entities;
using System.Data;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public interface IRoleRepository
    {
        Task<Roles> AddAsync(Roles role);
        Task<Roles> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Roles role);
        Task<bool> DeleteAsync(int id);
    }
}