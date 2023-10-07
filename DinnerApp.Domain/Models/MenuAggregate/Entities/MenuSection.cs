using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.MenuAggregate.ValueObjects;

namespace DinnerApp.Domain.Models.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    public string Name { get; private set; }
    public string Description { get; private set; }

    public MenuSection(MenuSectionId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        MenuSection section =new(MenuSectionId.CreateUnique(), name, description);
        section._items.AddRange(items);
        return section;
    }

}
