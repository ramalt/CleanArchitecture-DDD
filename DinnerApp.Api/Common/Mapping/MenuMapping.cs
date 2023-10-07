using Mapster;

using DinnerApp.Application.Menu.Command.CreateMenu;
using DinnerApp.Contracts.Menu;
using DinnerApp.Domain.Models.MenuAggregate;

using MenuSectionEntity = DinnerApp.Domain.Models.MenuAggregate.Entities.MenuSection;
using MenuItemEntity = DinnerApp.Domain.Models.MenuAggregate.Entities.MenuItem;

namespace DinnerApp.Api.Common.Mapping;

public class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);
        
        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dId => dId.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(rId => rId.Value));

        config.NewConfig<MenuSectionEntity, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItemEntity, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        

    }
}
