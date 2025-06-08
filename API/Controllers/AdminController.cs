using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpGet("secure-data")]
    public IActionResult GetSecureData()
    {
        return Ok("Only Admins can access this");
    }
}