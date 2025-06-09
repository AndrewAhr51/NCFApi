using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Application.Services;

public class ReceiptService : IReceiptService
{
    private readonly IReceiptRepository _receiptRepository;

    public ReceiptService(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<IEnumerable<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _receiptRepository.GetAllAsync();
        return receipts.Select(r => MapToDto(r));
    }

    public async Task<ReceiptDto> GetByIdAsync(int receiptId)
    {
        var receipt = await _receiptRepository.GetByIdAsync(receiptId);
        return receipt != null ? MapToDto(receipt) : null;
    }

    public async Task AddAsync(ReceiptDto receiptDto)
    {
        var receipt = new Receipt
        {
            DonationId = receiptDto.DonationId,
            DonorId = receiptDto.DonorId,
            OrganizationId = receiptDto.OrganizationId,
            PaymentMethodId = receiptDto.PaymentMethodId,
            StatusId = receiptDto.StatusId,
            IssuedDate = receiptDto.IssuedDate,
            ReceiptNumber = receiptDto.ReceiptNumber,
            Amount = receiptDto.Amount,
            Notes = receiptDto.Notes
        };

        await _receiptRepository.AddAsync(receipt);
    }

    public async Task UpdateAsync(int receiptId, ReceiptDto receiptDto)
    {
        var existingReceipt = await _receiptRepository.GetByIdAsync(receiptId);
        if (existingReceipt == null) return;

        existingReceipt.StatusId = receiptDto.StatusId;
        existingReceipt.Notes = receiptDto.Notes;
        existingReceipt.Amount = receiptDto.Amount;

        await _receiptRepository.UpdateAsync(existingReceipt);
    }

    public async Task DeleteAsync(int receiptId)
    {
        await _receiptRepository.DeleteAsync(receiptId);
    }

    private ReceiptDto MapToDto(Receipt receipt)
    {
        return new ReceiptDto
        {
            ReceiptId = receipt.ReceiptId,
            DonationId = receipt.DonationId,
            DonorId = receipt.DonorId,
            OrganizationId = receipt.OrganizationId,
            PaymentMethodId = receipt.PaymentMethodId,
            StatusId = receipt.StatusId,
            IssuedDate = receipt.IssuedDate,
            ReceiptNumber = receipt.ReceiptNumber,
            Amount = receipt.Amount,
            Notes = receipt.Notes
        };
    }
}