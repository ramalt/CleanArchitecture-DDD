using MenuAggregate = DinnerApp.Domain.Models.MenuAggregate.Menu;

using MediatR;
using DinnerApp.Domain.Models.Host.ValueObjects;

namespace DinnerApp.Application.Menu.Command.CreateMenu;

public record CreateMenuCommand(string Name,
                                string Description,
                                string HostId,
                                List<MenuSectionCommand> Sections) : IRequest<MenuAggregate>;

public record MenuSectionCommand(string Name,
                          string Description,
                          List<MenuItemCommand> Items);

public record MenuItemCommand(string Name,
                       string Description);
