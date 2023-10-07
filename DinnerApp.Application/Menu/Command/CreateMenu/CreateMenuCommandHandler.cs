using DinnerApp.Domain.Models.Host.ValueObjects;
using DinnerApp.Domain.Models.MenuAggregate.Entities;
using DinnerApp.Application.Common.Interfaces;
using MenuAggregate = DinnerApp.Domain.Models.MenuAggregate.Menu;

using MediatR;

namespace DinnerApp.Application.Menu.Command.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, MenuAggregate>
{
    private readonly IMenuRepository _repository;

    public CreateMenuCommandHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    Task<MenuAggregate> IRequestHandler<CreateMenuCommand, MenuAggregate>.Handle(CreateMenuCommand request,
                                                                                CancellationToken cancellationToken)
    {
        var menu = MenuAggregate.Create(
            request.Name,
            request.Description,
            HostId.Create(request.HostId),
            request.Sections.Select(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.Select(item => MenuItem.Create(
                    item.Name,
                    item.Description
                )).ToList())).ToList());

        _repository.Add(menu);

        return Task.FromResult(menu);
    }
}


