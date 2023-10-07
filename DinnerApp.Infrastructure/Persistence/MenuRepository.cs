using DinnerApp.Application.Common.Interfaces;
using DinnerApp.Domain.Models.MenuAggregate;

namespace DinnerApp.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
