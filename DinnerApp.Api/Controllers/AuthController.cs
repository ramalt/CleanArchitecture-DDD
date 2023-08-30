using Microsoft.AspNetCore.Mvc;
using DinnerApp.Contracts.Authentication;
using DinnerApp.Application.Services.Authentication;
using MediatR;
using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Queries.Login;

namespace DinnerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        AuthResult authResult = await _mediator.Send(command);

        AuthResponse response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        AuthResult authResult = await _mediator.Send(query);

        AuthResponse response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }
}
