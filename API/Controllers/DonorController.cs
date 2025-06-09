using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.Entities;
using NCFApi.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        // ✅ GET: api/donor/{id} → Fetch a single donor
        [HttpGet("{id}")]
        public async Task<ActionResult<Donor>> GetDonorById(int id)
        {
            var donor = await _donorService.GetDonorByIdAsync(id);
            if (donor == null)
                return NotFound();

            return Ok(donor);
        }

        // ✅ GET: api/donor → Fetch all donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donor>>> GetAllDonors()
        {
            return Ok(await _donorService.GetAllDonorsAsync());
        }

        // ✅ POST: api/donor → Create a new donor
        [HttpPost]
        public async Task<ActionResult> AddDonor([FromBody] Donor donor)
        {
            await _donorService.AddDonorAsync(donor);
            return CreatedAtAction(nameof(GetDonorById), new { id = donor.DonerId }, donor);
        }

        // ✅ PUT: api/donor/{id} → Update a donor
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDonor(int id, [FromBody] Donor donor)
        {
            if (id != donor.DonerId)
                return BadRequest();

            await _donorService.UpdateDonorAsync(donor);
            return NoContent();
        }

        // ✅ DELETE: api/donor/{id} → Delete a donor
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonor(int id)
        {
            await _donorService.DeleteDonorAsync(id);
            return NoContent();
        }
    }
}