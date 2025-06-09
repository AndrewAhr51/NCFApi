using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _context;

        public DonorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Donor?> GetByIdAsync(int donorId)
        {
            return await _context.Donors.FindAsync(donorId);
        }

        public async Task<IEnumerable<Donor>> GetAllAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task<Donor> AddAsync(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

        public async Task<bool> UpdateAsync(Donor donor)
        {
            _context.Donors.Update(donor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int donorId)
        {
            var donor = await _context.Donors.FindAsync(donorId);
            if (donor == null) return false;

            _context.Donors.Remove(donor);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}