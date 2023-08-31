using Microsoft.AspNetCore.Mvc;
using DinnerApp.Contracts.Authentication;
using DinnerApp.Application.Services.Authentication;
using MediatR;
using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace DinnerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        AuthResult authResult = await _mediator.Send(command);

        return Ok(_mapper.Map<AuthResponse>(authResult));


    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);

        AuthResult authResult = await _mediator.Send(query);

        return Ok(_mapper.Map<AuthResponse>(authResult));


    }
}
