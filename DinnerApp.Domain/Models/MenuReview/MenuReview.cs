using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.MenuReview.ValueObjects;

namespace DinnerApp.Domain.Models.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuReview(MenuReviewId id) : base(id)
    {
    }
}
