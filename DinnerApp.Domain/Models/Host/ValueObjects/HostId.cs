namespace DinnerApp.Domain.Models.Host.ValueObjects;

public record HostId
{
    public Guid Value { get; init; }

    public HostId(Guid value) => Value = value;

    public static HostId Create(string id)
    {
        return new(Guid.Parse(id));
    }
}
