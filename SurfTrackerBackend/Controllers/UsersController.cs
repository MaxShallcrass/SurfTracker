using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurfTrackerBackend.Services.Interfaces;

namespace SurfTrackerBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUser()
    {
        var cognitoId = User.FindFirst("sub")?.Value;

        if (string.IsNullOrEmpty(cognitoId))
            return Unauthorized();

        await userService.CreateUserAsync(cognitoId);
        return StatusCode(StatusCodes.Status201Created);
    }
}
