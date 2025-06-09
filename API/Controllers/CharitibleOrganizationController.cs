
using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.DTOs;
using NCFApi.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharitableOrganizationsController : ControllerBase
{
    private readonly ICharitableOrganizationService _organizationService;

    public CharitableOrganizationsController(ICharitableOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharitableOrganizationDto>>> GetAllOrganizations()
    {
        var organizations = await _organizationService.GetAllAsync();
        return Ok(organizations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CharitableOrganizationDto>> GetOrganizationById(int id)
    {
        var organization = await _organizationService.GetByIdAsync(id);
        if (organization == null)
        {
            return NotFound();
        }
        return Ok(organization);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrganization([FromBody] CharitableOrganizationDto organizationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _organizationService.AddAsync(organizationDto);
        return CreatedAtAction(nameof(GetOrganizationById), new { id = organizationDto.OrganizationId }, organizationDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrganization(int id, [FromBody] CharitableOrganizationDto organizationDto)
    {
        var existingOrganization = await _organizationService.GetByIdAsync(id);
        if (existingOrganization == null)
        {
            return NotFound();
        }

        await _organizationService.UpdateAsync(id, organizationDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrganization(int id)
    {
        var organization = await _organizationService.GetByIdAsync(id);
        if (organization == null)
        {
            return NotFound();
        }

        await _organizationService.DeleteAsync(id);
        return NoContent();
    }
}
