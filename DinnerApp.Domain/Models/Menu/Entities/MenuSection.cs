using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.Menu.ValueObjects;

namespace DinnerApp.Domain.Models.Menu.Entities;

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

    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }

}
