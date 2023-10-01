using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerApp.Domain.Models.MenuReview.ValueObjects;

public record MenuReviewId
{
    public Guid Value { get; init; }

    public MenuReviewId(Guid value) => Value = value;

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
