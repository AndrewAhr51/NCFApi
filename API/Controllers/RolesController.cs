using Microsoft.AspNetCore.Mvc;
using NCFApi.Application.Services;
using NCFApi.Domain.DTOs;
using NCFApi.Infrastructure.Repositories;
using System.Threading.Tasks;

[Route("api/roles")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    // ✅ Create a role
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto roleDto)
    {
        var createdRole = await _roleService.CreateRoleAsync(roleDto);
        return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.RoleId }, createdRole);
    }

    // ✅ Get a role by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        if (role == null) return NotFound();
        return Ok(role);
    }

    // ✅ Update a role
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, [FromBody] CreateRoleDto roleDto)
    {
        var updated = await _roleService.UpdateRoleAsync(id, roleDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    // ✅ Delete a role
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var deleted = await _roleService.DeleteRoleAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}