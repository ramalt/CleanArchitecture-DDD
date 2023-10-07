namespace DinnerApp.Domain.Models.Host.ValueObjects;

public record HostId
{
    public Guid Value { get; init; }

    public HostId(Guid value) => Value = value;

    public static HostId Create(Guid id)
    {
        // return new(Guid.Parse(id));
        return new(id);
    }
}
