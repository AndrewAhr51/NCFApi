using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories;

public class ReceiptRepository : IReceiptRepository
{
    private readonly DbContext _context;

    public ReceiptRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Receipt>> GetAllAsync()
    {
        return await _context.Set<Receipt>().ToListAsync();
    }

    public async Task<Receipt> GetByIdAsync(int receiptId)
    {
        return await _context.Set<Receipt>().FindAsync(receiptId);
    }

    public async Task AddAsync(Receipt receipt)
    {
        await _context.Set<Receipt>().AddAsync(receipt);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Receipt receipt)
    {
        _context.Set<Receipt>().Update(receipt);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int receiptId)
    {
        var receipt = await GetByIdAsync(receiptId);
        if (receipt != null)
        {
            _context.Set<Receipt>().Remove(receipt);
            await _context.SaveChangesAsync();
        }
    }
}
