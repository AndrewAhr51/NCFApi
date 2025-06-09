using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.Entities;
using NCFApi.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharitableOrganizationController : ControllerBase
    {
        private readonly ICharitableOrganizationService _organizationService;

        public CharitableOrganizationController(ICharitableOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        // ✅ GET: api/charitableorganization/{id} → Fetch a single organization
        [HttpGet("{id}")]
        public async Task<ActionResult<CharitableOrganization>> GetOrganizationById(int id)
        {
            var organization = await _organizationService.GetOrganizationByIdAsync(id);
            if (organization == null)
                return NotFound();

            return Ok(organization);
        }

        // ✅ GET: api/charitableorganization → Fetch all organizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharitableOrganization>>> GetAllOrganizations()
        {
            return Ok(await _organizationService.GetAllOrganizationsAsync());
        }

        // ✅ POST: api/charitableorganization → Create a new organization
        [HttpPost]
        public async Task<ActionResult> AddOrganization([FromBody] CharitableOrganization organization)
        {
            await _organizationService.AddOrganizationAsync(organization);
            return CreatedAtAction(nameof(GetOrganizationById), new { id = organization.OrganizationId }, organization);
        }

        // ✅ PUT: api/charitableorganization/{id} → Update an organization
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrganization(int id, [FromBody] CharitableOrganization organization)
        {
            if (id != organization.OrganizationId)
                return BadRequest();

            await _organizationService.UpdateOrganizationAsync(organization);
            return NoContent();
        }

        // ✅ DELETE: api/charitableorganization/{id} → Delete an organization
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrganization(int id)
        {
            await _organizationService.DeleteOrganizationAsync(id);
            return NoContent();
        }
    }
}