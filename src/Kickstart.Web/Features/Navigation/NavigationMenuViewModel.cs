using System.Collections.Generic;

namespace Kickstart.Web.Features.Navigation;

public class NavigationMenuViewModel
{
    public string Name { get; set; }

    public IEnumerable<NavigationItemViewModel> Items { get; set; }
}
