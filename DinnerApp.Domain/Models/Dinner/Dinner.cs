using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.Host.ValueObjects;

namespace DinnerApp.Domain.Models.Dinner;

public sealed class Dinner : AggregateRoot<HostId>
{
    public Dinner(HostId id) : base(id)
    {
    }
}
