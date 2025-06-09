using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCFApi.Application.Services;
using NCFApi.Domain.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/donors")]
[ApiController]
[Authorize] // ✅ Any authenticated user can access the API
public class DonorController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    // ✅ Get donor profile (Authenticated users can access)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDonorProfile(int id)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        // ✅ Allow self-access OR Admin override
        var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;
        if (id != currentUserId && currentUserRole != "Admin")
        {
            return Forbid(); // ❌ Prevents unauthorized access
        }

        var donor = await _donorService.GetByIdAsync(id);
        return donor != null ? Ok(donor) : NotFound();
    }

    // ✅ Update donor profile (Only self-update unless Admin)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDonorProfile(int id, [FromBody] UpdateDonorDto donorDto)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;

        // ✅ Allow self-updates OR Admin updates
        if (id != currentUserId && currentUserRole != "Admin")
        {
            return Forbid(); // ❌ Prevents unauthorized updates
        }

        var updated = await _donorService.UpdateDonorProfileAsync(id, donorDto, currentUserId);
        return updated ? NoContent() : NotFound();
    }
}