using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCFApi.Application.DTOs;
using NCFApi.Application.Services;
using NCFApi.Domain.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/donors")]
[ApiController]
public class DonorController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    // ✅ Get donor profile (Self-access only)
    
    [Authorize(Roles = "Donor, Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDonorProfile(int id)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        if (id != currentUserId) return Forbid(); // ❌ Prevents unauthorized access

        var donor = await _donorService.GetByIdAsync(id);
        return donor != null ? Ok(donor) : NotFound();
    }

    // ✅ Update donor profile (Only self-update allowed)
    
    [Authorize(Roles = "Donor, Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDonorProfile(int id, [FromBody] UpdateDonorDto donorDto)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var updated = await _donorService.UpdateDonorProfileAsync(id, donorDto, currentUserId);

        return updated ? NoContent() : Forbid(); // ✅ Prevents unauthorized updates
    }
}