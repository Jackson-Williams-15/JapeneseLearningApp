namespace JapaneseLearning.Controllers;
using JapaneseLearning.Interfaces;
using JapaneseLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JapaneseLearning.Helpers;
using JapaneseLearning.DTOs;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate(LoginRequestDTO loginDetails) {
        var credentials = new Credentials
        {
            Username = loginDetails.Username,
            Password = loginDetails.Password
        };

        var authInfo = await _userService.GetAuthenticationInfo(credentials);

        if (authInfo is null)
        {
            return Unauthorized();
        }

        return Ok(authInfo);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(Credentials credentials) {
        var user = await _userService.RegisterUser(credentials);
        if (user is null)
        {
            return BadRequest(new { Message = "User already exists." });
        }

        return Ok();
    }

    [HttpGet("confirm/{userId}")]
    public async Task<IActionResult> ConfirmAccount(int userId)
    {
        var result = await _userService.ConfirmAccount(userId);
        if (result == null)
        {
            return NotFound(new { Message = "User not found." });
        }
        return Ok(result);
    }
}