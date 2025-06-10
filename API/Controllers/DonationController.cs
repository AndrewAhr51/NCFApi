using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.Entities;
using NCFApi.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        // ✅ GET: api/donation/{id} → Fetch a single donation
        [HttpGet("{id}")]
        public async Task<ActionResult<Donation>> GetDonationById(int id)
        {
            var donation = await _donationService.GetDonationByIdAsync(id);
            if (donation == null)
                return NotFound();

            return Ok(donation);
        }

        // ✅ GET: api/donation → Fetch all donations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donation>>> GetAllDonations()
        {
            return Ok(await _donationService.GetAllDonationsAsync());
        }

        // ✅ POST: api/donation → Create a new donation
        [HttpPost]
        public async Task<ActionResult> AddDonation([FromBody] Donation donation)
        {
            // Ensure nullable fields default to an empty string
            donation.PaymentMethod ??= string.Empty;
            donation.DonationReference ??= string.Empty;
            donation.Status ??= string.Empty;
            donation.Notes ??= string.Empty;

            await _donationService.AddDonationAsync(donation);
            return CreatedAtAction(nameof(GetDonationById), new { id = donation.DonationId }, donation);
        }

        // ✅ PUT: api/donation/{id} → Update a donation
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDonation(int id, [FromBody] Donation donation)
        {
            if (id != donation.DonationId)
                return BadRequest();

            // Ensure nullable fields default to an empty string
            donation.PaymentMethod ??= string.Empty;
            donation.DonationReference ??= string.Empty;
            donation.Status ??= string.Empty;
            donation.Notes ??= string.Empty;

            await _donationService.UpdateDonationAsync(donation);
            return NoContent();
        }

        // ✅ DELETE: api/donation/{id} → Delete a donation
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonation(int id)
        {
            await _donationService.DeleteDonationAsync(id);
            return NoContent();
        }
    }
}