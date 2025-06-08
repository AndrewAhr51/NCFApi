using NCFApi.Application.DTOs;
using NCFApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public interface IPaymentMethodService
    {
        Task<PaymentMethodDto> CreatePaymentMethodAsync(PaymentMethodDto paymentMethodDto);
        Task<PaymentMethodDto?> GetPaymentMethodByIdAsync(int id);
        Task<IEnumerable<PaymentMethodDto>> GetAllPaymentMethodsAsync();
        Task<bool> UpdatePaymentMethodAsync(int id, PaymentMethodDto paymentMethodDto);
        Task<bool> DeletePaymentMethodAsync(int id);
    }
}