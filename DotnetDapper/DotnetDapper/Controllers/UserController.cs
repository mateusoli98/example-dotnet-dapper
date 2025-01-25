using DotnetDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetDapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();

        if (!users.Success)
        {
            return BadRequest(users.Message);
        }

        return Ok(users);
    }
}
