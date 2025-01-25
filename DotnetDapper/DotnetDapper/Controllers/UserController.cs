using DotnetDapper.Models;
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var user = await _userService.GetById(id);

        if (!user.Success)
        {
            return BadRequest(user.Message);
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequestDTO request)
    {
        var res = await _userService.CreateUser(request);
        if (!res.Success)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, res.Message);
        }
        return Created();
    }
}
