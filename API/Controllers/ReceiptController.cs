using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NCFApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceiptsController : ControllerBase
{
    private readonly IReceiptRepository _receiptRepository;

    public ReceiptsController(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReceiptDto>>> GetAllReceipts()
    {
        var receipts = await _receiptRepository.GetAllAsync();
        return Ok(receipts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReceiptDto>> GetReceiptById(int id)
    {
        var receipt = await _receiptRepository.GetByIdAsync(id);
        if (receipt == null)
        {
            return NotFound();
        }
        return Ok(receipt);
    }

    [HttpPost]
    public async Task<ActionResult> CreateReceipt([FromBody] ReceiptDto receiptDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
        return CreatedAtAction(nameof(GetReceiptById), new { id = receipt.ReceiptId }, receipt);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReceipt(int id, [FromBody] ReceiptDto receiptDto)
    {
        var existingReceipt = await _receiptRepository.GetByIdAsync(id);
        if (existingReceipt == null)
        {
            return NotFound();
        }

        existingReceipt.StatusId = receiptDto.StatusId;
        existingReceipt.Notes = receiptDto.Notes;
        existingReceipt.Amount = receiptDto.Amount;

        await _receiptRepository.UpdateAsync(existingReceipt);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReceipt(int id)
    {
        var receipt = await _receiptRepository.GetByIdAsync(id);
        if (receipt == null)
        {
            return NotFound();
        }

        await _receiptRepository.DeleteAsync(id);
        return NoContent();
    }
}