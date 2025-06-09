using NCFApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services;

public interface IDonationService
{
    Task<IEnumerable<DonationDto>> GetAllAsync();
    Task<DonationDto> GetByIdAsync(int donationId);
    Task<IEnumerable<DonationDto>> GetByDonorIdAsync(int donorId);
    Task<IEnumerable<DonationDto>> GetByOrganizationIdAsync(int organizationId);
    Task AddAsync(DonationDto donationDto);
    Task UpdateAsync(int donationId, DonationDto donationDto);
    Task DeleteAsync(int donationId);
}