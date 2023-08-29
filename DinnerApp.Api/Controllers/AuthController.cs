using Microsoft.AspNetCore.Mvc;
using DinnerApp.Contracts.Authentication;
using DinnerApp.Application.Services.Authentication;
using DinnerApp.Api.Filters;

namespace DinnerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        AuthResult authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        AuthResponse response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        AuthResult authResult = _authenticationService.Login(
            request.Email,
            request.Password);

        AuthResponse response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }
}
