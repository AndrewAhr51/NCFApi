using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<PaymentMethodDto> CreatePaymentMethodAsync(PaymentMethodDto paymentMethodDto)
        {
            var newPaymentMethod = new PaymentMethod
            {
                MethodName = paymentMethodDto.MethodName, // ✅ Ensuring correct property name
                Description = paymentMethodDto.Description,
                IsActive = paymentMethodDto.IsActive // Defaulting to active status

            };

            var createdPaymentMethod = await _paymentMethodRepository.AddAsync(newPaymentMethod);
            return new PaymentMethodDto { Id = createdPaymentMethod.Id, MethodName = createdPaymentMethod.MethodName, Description = createdPaymentMethod.Description, IsActive = createdPaymentMethod.IsActive };
        }

        public async Task<PaymentMethodDto?> GetPaymentMethodByIdAsync(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null) return null;

            return new PaymentMethodDto { Id = paymentMethod.Id, MethodName = paymentMethod.MethodName, Description = paymentMethod.Description, IsActive= paymentMethod.IsActive };
        }

        public async Task<IEnumerable<PaymentMethodDto>> GetAllPaymentMethodsAsync()
        {
            var paymentMethods = await _paymentMethodRepository.GetAllAsync();
            return paymentMethods.Select(pm => new PaymentMethodDto { Id = pm.Id, MethodName = pm.MethodName, Description = pm.Description, IsActive= pm.IsActive });
        }

        public async Task<bool> UpdatePaymentMethodAsync(int id, PaymentMethodDto paymentMethodDto)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null || string.IsNullOrEmpty(paymentMethodDto.MethodName) || string.IsNullOrEmpty(paymentMethodDto.Description))
                return false; // ✅ Prevents updating with invalid data

            paymentMethod.MethodName = paymentMethodDto.MethodName;
            paymentMethod.Description = paymentMethodDto.Description;

            return await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }

        public async Task<bool> DeletePaymentMethodAsync(int id)
        {
            return await _paymentMethodRepository.DeleteAsync(id);
        }
    }
}