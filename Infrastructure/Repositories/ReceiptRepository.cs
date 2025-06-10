using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AppDbContext _context;

        public ReceiptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Receipt?> GetReceiptByIdAsync(int id)
        {
            return await _context.Receipts.FindAsync(id);
        }

        public async Task<IEnumerable<Receipt>> GetAllReceiptsAsync()
        {
            return await _context.Receipts.ToListAsync();
        }

        public async Task AddReceiptAsync(Receipt receipt)
        {
            await _context.Receipts.AddAsync(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReceiptAsync(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceiptAsync(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipts.Remove(receipt);
                await _context.SaveChangesAsync();
            }
        }
    }
}