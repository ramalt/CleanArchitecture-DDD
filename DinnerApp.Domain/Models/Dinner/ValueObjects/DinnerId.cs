using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerApp.Domain.Models.Dinner.ValueObjects;

public record DinnerId
{
    public Guid Value { get; init; }

    public DinnerId(Guid value) => Value = value;

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
