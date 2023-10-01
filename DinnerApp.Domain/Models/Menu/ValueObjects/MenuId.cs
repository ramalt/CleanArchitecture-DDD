namespace DinnerApp.Domain.Models.Menu.ValueObjects;

public record MenuId
{
    public Guid Value { get; init; }

    public MenuId(Guid value) => Value = value;

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

}
