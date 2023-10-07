using DinnerApp.Domain.Models.Host.ValueObjects;
using MenuEntity = DinnerApp.Domain.Models.MenuAggregate.Menu;

using MediatR;

namespace DinnerApp.Application.Menu.Command.CreateMenu;

public record CreateMenuCommand(string Name,
                                string Description,
                                Guid HostId,
                                List<MenuSectionCommand> Sections) : IRequest<MenuEntity>;

public record MenuSectionCommand(string Name,
                          string Description,
                          List<MenuItemCommand> Items);

public record MenuItemCommand(string Name,
                       string Description);
