using MenuEntity = DinnerApp.Domain.Models.MenuAggregate.Menu;
namespace DinnerApp.Application.Common.Interfaces;

public interface IMenuRepository
{
    void Add(MenuEntity menu);    
}
