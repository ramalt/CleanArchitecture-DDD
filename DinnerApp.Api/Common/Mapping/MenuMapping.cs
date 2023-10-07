using DinnerApp.Application.Menu.Command.CreateMenu;
using DinnerApp.Contracts.Menu;

using Mapster;

namespace DinnerApp.Api.Common.Mapping;

public class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, Guid HostId), CreateMenuCommand>()
              .Map(dest => dest.HostId, src => src.HostId)
              .Map(dest => dest, src => src.Request);
    }
}
