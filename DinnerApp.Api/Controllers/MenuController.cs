using DinnerApp.Application.Menu.Command.CreateMenu;
using DinnerApp.Contracts.Menu;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[ApiController]
[Route("host/{hostId}/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

       public MenuController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request,[FromRoute] string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var created = await _mediator.Send(command);

        var mapped = _mapper.Map<MenuResponse>(created);
        return Ok(created);
    }
}
