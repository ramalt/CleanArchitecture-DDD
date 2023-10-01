namespace DinnerApp.Domain.Models.Menu.ValueObjects;

public record MenuSectionId
{
        public Guid Value { get; init; }

    public MenuSectionId(Guid value) => Value = value;

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
