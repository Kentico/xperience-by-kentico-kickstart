using System.Linq;

using CMS.Websites;

using Microsoft.IdentityModel.Tokens;

namespace Kickstart.Web.Features.Navigation;

public class NavigationService : INavigationService
{

    public NavigationService()
    { }

    public NavigationItemViewModel GetNavigationItemViewModel(NavigationItem navigationItem)
    {
        if (navigationItem?.NavigationItemTarget?.IsNullOrEmpty() ?? true)
        {
            return null;
        }

        var targetUrl = navigationItem.NavigationItemTarget.FirstOrDefault().GetUrl();

        return new NavigationItemViewModel
        {
            Title = navigationItem.NavigationItemTitle,
            Url = targetUrl.RelativePath
        };
    }

    public NavigationMenuViewModel GetNavigationMenuViewModel(NavigationMenu navigationMenu)
    {
        if (navigationMenu?.NavigationMenuItems?.IsNullOrEmpty() ?? true)
        {
            return null;
        }

        var menuItems = navigationMenu.NavigationMenuItems
            .Select(GetNavigationItemViewModel)
            .Where(x => x != null);

        return new NavigationMenuViewModel
        {
            Name = navigationMenu.NavigationMenuDisplayName,
            Items = menuItems
        };
    }
}
