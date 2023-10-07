using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerApp.Domain.Models.MenuAggregate.ValueObjects;

public record MenuItemId
{
    public Guid Value { get; init; }

    public MenuItemId(Guid value) => Value = value;

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
