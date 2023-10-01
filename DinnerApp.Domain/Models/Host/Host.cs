using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.Host.ValueObjects;

namespace DinnerApp.Domain.Models.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public Host(HostId id) : base(id)
    {
    }
}
