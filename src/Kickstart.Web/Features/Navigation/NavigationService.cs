using System;
using System.Linq;
using System.Threading.Tasks;
using CMS.Websites;
using Kentico.Content.Web.Mvc.Routing;

namespace Kickstart.Web.Features.Navigation;

public class NavigationService : INavigationService
{
    private readonly IWebPageUrlRetriever webPageUrlRetriever;
    private readonly IPreferredLanguageRetriever preferredLanguageRetriever;
    public NavigationService(IWebPageUrlRetriever webPageUrlRetriever,
    IPreferredLanguageRetriever preferredLanguageRetriever)
    {
        this.webPageUrlRetriever = webPageUrlRetriever;
        this.preferredLanguageRetriever = preferredLanguageRetriever;
    }
    public async Task<NavigationItemViewModel> GetNavigationItemViewModel(NavigationItem navigationItem)
    {
        if (navigationItem == null || navigationItem.NavigationItemTarget == null || !navigationItem.NavigationItemTarget.Any())
        {
            return null;
        }

        var targetGuid = navigationItem.NavigationItemTarget.FirstOrDefault().WebPageGuid;
        
        var targetUrl = await webPageUrlRetriever.Retrieve(targetGuid, preferredLanguageRetriever.Get());

        return new NavigationItemViewModel
        {
            Title = navigationItem.NavigationItemTitle,
            Url = targetUrl.RelativePath
        };
    }

    public async Task<NavigationMenuViewModel> GetNavigationMenuViewModel(NavigationMenu navigationMenu)
    {
        if (navigationMenu == null || navigationMenu.NavigationMenuItems == null || !navigationMenu.NavigationMenuItems.Any())
        {
            return null;
        }

        var menuItems = await Task.WhenAll(navigationMenu.NavigationMenuItems.Select(GetNavigationItemViewModel));

        return new NavigationMenuViewModel
        {
            Name = navigationMenu.NavigationMenuDisplayName,
            Items = menuItems
        };
    }
}
