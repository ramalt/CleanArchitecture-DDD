using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.Menu.ValueObjects;

namespace DinnerApp.Domain.Models.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{

    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }
    public string Description { get; private set; }

    public MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
