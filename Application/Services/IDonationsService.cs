using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public interface IDonationService
    {
        Task<Donation?> GetDonationByIdAsync(int id);
        Task<IEnumerable<Donation>> GetAllDonationsAsync();
        Task AddDonationAsync(Donation donation);
        Task UpdateDonationAsync(Donation donation);
        Task DeleteDonationAsync(int id);
    }
}