using Microsoft.AspNetCore.Mvc;
using NCFApi.Application.Services;
using NCFApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/payment-methods")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;

    public PaymentMethodController(IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    // ✅ Create a payment method
    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod([FromBody] PaymentMethodDto paymentMethodDto)
    {
        var createdPaymentMethod = await _paymentMethodService.CreatePaymentMethodAsync(paymentMethodDto);
        return CreatedAtAction(nameof(GetPaymentMethodById), new { id = createdPaymentMethod.Id }, createdPaymentMethod);
    }

    // ✅ Get a payment method by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentMethodById(int id)
    {
        var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
        if (paymentMethod == null) return NotFound();

        return Ok(paymentMethod);
    }

    // ✅ Get all payment methods
    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
        return Ok(paymentMethods);
    }

    // ✅ Update a payment method
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePaymentMethod(int id, [FromBody] PaymentMethodDto paymentMethodDto)
    {
        var updated = await _paymentMethodService.UpdatePaymentMethodAsync(id, paymentMethodDto);
        if (!updated) return NotFound();

        return NoContent();
    }

    // ✅ Delete a payment method
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaymentMethod(int id)
    {
        var deleted = await _paymentMethodService.DeletePaymentMethodAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}