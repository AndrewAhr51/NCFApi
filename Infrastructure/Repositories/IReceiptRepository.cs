using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public interface IReceiptRepository
    {
        Task<Receipt?> GetReceiptByIdAsync(int id);
        Task<IEnumerable<Receipt>> GetAllReceiptsAsync();
        Task AddReceiptAsync(Receipt receipt);
        Task UpdateReceiptAsync(Receipt receipt);
        Task DeleteReceiptAsync(int id);
    }
}