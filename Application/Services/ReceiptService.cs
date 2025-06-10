using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Receipt?> GetReceiptByIdAsync(int id)
        {
            return await _receiptRepository.GetReceiptByIdAsync(id);
        }

        public async Task<IEnumerable<Receipt>> GetAllReceiptsAsync()
        {
            return await _receiptRepository.GetAllReceiptsAsync();
        }

        public async Task AddReceiptAsync(Receipt receipt)
        {
            await _receiptRepository.AddReceiptAsync(receipt);
        }

        public async Task UpdateReceiptAsync(Receipt receipt)
        {
            await _receiptRepository.UpdateReceiptAsync(receipt);
        }

        public async Task DeleteReceiptAsync(int id)
        {
            await _receiptRepository.DeleteReceiptAsync(id);
        }
    }
}