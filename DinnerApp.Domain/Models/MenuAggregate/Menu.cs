using DinnerApp.Domain.Abstracts;
using DinnerApp.Domain.Models.Dinner.ValueObjects;
using DinnerApp.Domain.Models.Host.ValueObjects;
using DinnerApp.Domain.Models.MenuAggregate.Entities;
using DinnerApp.Domain.Models.MenuAggregate.ValueObjects;
using DinnerApp.Domain.Models.MenuReview.ValueObjects;

namespace DinnerApp.Domain.Models.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float AverageRating { get; private set; }
    public HostId HostId { get; private set; }

    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviews = new();

    public IReadOnlyList<MenuSection> MenuSections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviews.AsReadOnly();

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    private Menu(MenuId id,
                 string name,
                 string description,
                 HostId hostId,
                 DateTime createdDate,
                 DateTime updatedDate) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        
    }

    public static Menu Create(string name,
                              string description,
                              HostId hostId,
                              List<MenuSection>? sections = null)
    {
        Menu menu =  new(MenuId.CreateUnique(),
                         name,
                         description,
                         hostId,
                         DateTime.UtcNow,
                         DateTime.UtcNow);

        if (sections is not null)
            menu._sections.AddRange(sections);
        
        return menu;
    }
}
