using System.Threading.Tasks;

namespace Kickstart.Web.Features.Navigation;

public interface INavigationService
{
    Task<NavigationItemViewModel> GetNavigationItemViewModel(NavigationItem navigationItem);

    Task<NavigationMenuViewModel> GetNavigationMenuViewModel(NavigationMenu navigationMenu);
}
