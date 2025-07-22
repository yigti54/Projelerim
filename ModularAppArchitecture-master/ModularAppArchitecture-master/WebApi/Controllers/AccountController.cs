using Business.Abstract;
using Core.Utilities.Security.Authorization;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/user")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        var result = accountService.Login(loginDto);
        return Ok(result);
    }

    [AuthorizeRoles("User")]
    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerDto)
    {
        var result = accountService.Register(registerDto);
        return Ok(result);
    }
}