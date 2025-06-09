using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories;

public interface IReceiptRepository
{
    Task<IEnumerable<Receipt>> GetAllAsync();
    Task<Receipt> GetByIdAsync(int receiptId);
    Task AddAsync(Receipt receipt);
    Task UpdateAsync(Receipt receipt);
    Task DeleteAsync(int receiptId);
}