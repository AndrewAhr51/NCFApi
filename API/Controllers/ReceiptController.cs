using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.Entities;
using NCFApi.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        // ✅ GET: api/receipt/{id} → Fetch a single receipt
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> GetReceiptById(int id)
        {
            var receipt = await _receiptService.GetReceiptByIdAsync(id);
            if (receipt == null)
                return NotFound();

            return Ok(receipt);
        }

        // ✅ GET: api/receipt → Fetch all receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetAllReceipts()
        {
            return Ok(await _receiptService.GetAllReceiptsAsync());
        }

        // ✅ POST: api/receipt → Create a new receipt
        [HttpPost]
        public async Task<ActionResult> AddReceipt([FromBody] Receipt receipt)
        {
            await _receiptService.AddReceiptAsync(receipt);
            return CreatedAtAction(nameof(GetReceiptById), new { id = receipt.ReceiptId }, receipt);
        }

        // ✅ PUT: api/receipt/{id} → Update a receipt
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReceipt(int id, [FromBody] Receipt receipt)
        {
            if (id != receipt.ReceiptId)
                return BadRequest();

            await _receiptService.UpdateReceiptAsync(receipt);
            return NoContent();
        }

        // ✅ DELETE: api/receipt/{id} → Delete a receipt
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReceipt(int id)
        {
            await _receiptService.DeleteReceiptAsync(id);
            return NoContent();
        }
    }
}