using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public class CharitableOrganizationRepository : ICharitableOrganizationRepository
    {
        private readonly AppDbContext _context;

        public CharitableOrganizationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CharitableOrganization?> GetOrganizationByIdAsync(int id)
        {
            return await _context.CharitableOrganizations.FindAsync(id);
        }

        public async Task<IEnumerable<CharitableOrganization>> GetAllOrganizationsAsync()
        {
            return await _context.CharitableOrganizations.ToListAsync();
        }

        public async Task AddOrganizationAsync(CharitableOrganization organization)
        {
            await _context.CharitableOrganizations.AddAsync(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrganizationAsync(CharitableOrganization organization)
        {
            _context.CharitableOrganizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            var organization = await _context.CharitableOrganizations.FindAsync(id);
            if (organization != null)
            {
                _context.CharitableOrganizations.Remove(organization);
                await _context.SaveChangesAsync();
            }
        }
    }
}