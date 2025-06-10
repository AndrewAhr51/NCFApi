using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public interface IDonorService
    {
        Task<Donor?> GetDonorByIdAsync(int id);
        Task<IEnumerable<Donor>> GetAllDonorsAsync();
        Task AddDonorAsync(Donor donor);
        Task UpdateDonorAsync(Donor donor);
        Task DeleteDonorAsync(int id);
    }
}