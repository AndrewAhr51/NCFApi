using NCFApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services;
public interface IReceiptService
{
    Task<IEnumerable<ReceiptDto>> GetAllAsync();
    Task<ReceiptDto> GetByIdAsync(int receiptId);
    Task AddAsync(ReceiptDto receiptDto);
    Task UpdateAsync(int receiptId, ReceiptDto receiptDto);
    Task DeleteAsync(int receiptId);
}