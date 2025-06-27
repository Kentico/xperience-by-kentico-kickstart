using System.Collections.Generic;
using System.Linq;

using Microsoft.IdentityModel.Tokens;

namespace Kickstart.Web.Features.Navigation;

public class NavigationMenuViewModel
{
    public string Name { get; set; }

    public IEnumerable<NavigationItemViewModel> Items { get; set; }

    public static NavigationMenuViewModel GetViewModel(NavigationMenu navigationMenu)
    {
        if (navigationMenu?.NavigationMenuItems?.IsNullOrEmpty() ?? true)
        {
            return null;
        }

        var menuItems = navigationMenu.NavigationMenuItems
            .Select(NavigationItemViewModel.GetViewModel)
            .Where(x => x != null);

        return new NavigationMenuViewModel
        {
            Name = navigationMenu.NavigationMenuDisplayName,
            Items = menuItems
        };
    }
}
