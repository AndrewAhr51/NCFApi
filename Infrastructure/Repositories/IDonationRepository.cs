using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories;

public interface IDonationRepository
{
    Task<IEnumerable<Donation>> GetAllAsync();
    Task<Donation> GetByIdAsync(int donationId);
    Task<IEnumerable<Donation>> GetByDonorIdAsync(int donorId);
    Task<IEnumerable<Donation>> GetByOrganizationIdAsync(int organizationId);
    Task AddAsync(Donation donation);
    Task UpdateAsync(Donation donation);
    Task DeleteAsync(int donationId);
}
