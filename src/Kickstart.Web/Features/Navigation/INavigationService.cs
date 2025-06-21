namespace Kickstart.Web.Features.Navigation;

public interface INavigationService
{
    NavigationItemViewModel GetNavigationItemViewModel(NavigationItem navigationItem);

    NavigationMenuViewModel GetNavigationMenuViewModel(NavigationMenu navigationMenu);
}
