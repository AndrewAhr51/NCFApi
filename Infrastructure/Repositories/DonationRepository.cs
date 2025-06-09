
using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly DbContext _context;

    public DonationRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Donation>> GetAllAsync()
    {
        return await _context.Set<Donation>().ToListAsync();
    }

    public async Task<Donation> GetByIdAsync(int donationId)
    {
        return await _context.Set<Donation>().FindAsync(donationId);
    }

    public async Task<IEnumerable<Donation>> GetByDonorIdAsync(int donorId)
    {
        return await _context.Set<Donation>()
                             .Where(d => d.DonorId == donorId)
                             .ToListAsync();
    }

    public async Task<IEnumerable<Donation>> GetByOrganizationIdAsync(int organizationId)
    {
        return await _context.Set<Donation>()
                             .Where(d => d.OrganizationId == organizationId)
                             .ToListAsync();
    }

    public async Task AddAsync(Donation donation)
    {
        await _context.Set<Donation>().AddAsync(donation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Donation donation)
    {
        _context.Set<Donation>().Update(donation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int donationId)
    {
        var donation = await GetByIdAsync(donationId);
        if (donation != null)
        {
            _context.Set<Donation>().Remove(donation);
            await _context.SaveChangesAsync();
        }
    }
}
