using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public interface IDonorRepository
    {
        Task<Donor?> GetByIdAsync(int donorId);
        Task<IEnumerable<Donor>> GetAllAsync();
        Task<Donor> AddAsync(Donor donor);
        Task<bool> UpdateAsync(Donor donor);
        Task<bool> DeleteAsync(int donorId);
    }
}