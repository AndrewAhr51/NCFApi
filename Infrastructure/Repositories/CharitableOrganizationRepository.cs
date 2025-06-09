using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories;

public class CharitableOrganizationRepository : ICharitableOrganizationRepository
{
    private readonly DbContext _context;

    public CharitableOrganizationRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CharitableOrganization>> GetAllAsync()
    {
        return await _context.Set<CharitableOrganization>().ToListAsync();
    }

    public async Task<CharitableOrganization> GetByIdAsync(int organizationId)
    {
        return await _context.Set<CharitableOrganization>().FindAsync(organizationId);
    }

    public async Task AddAsync(CharitableOrganization organization)
    {
        await _context.Set<CharitableOrganization>().AddAsync(organization);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CharitableOrganization organization)
    {
        _context.Set<CharitableOrganization>().Update(organization);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int organizationId)
    {
        var organization = await GetByIdAsync(organizationId);
        if (organization != null)
        {
            _context.Set<CharitableOrganization>().Remove(organization);
            await _context.SaveChangesAsync();
        }
    }
}