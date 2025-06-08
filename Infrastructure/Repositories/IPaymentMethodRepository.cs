using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> AddAsync(PaymentMethod paymentMethod);
        Task<PaymentMethod?> GetByIdAsync(int id);
        Task<IEnumerable<PaymentMethod>> GetAllAsync();
        Task<bool> UpdateAsync(PaymentMethod paymentMethod);
        Task<bool> DeleteAsync(int id);
    }
}