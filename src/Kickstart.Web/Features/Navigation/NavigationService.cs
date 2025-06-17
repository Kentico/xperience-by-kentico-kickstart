using System.Linq;
using System.Threading.Tasks;

using CMS.ContentEngine;
using CMS.Websites;
using CMS.Websites.Routing;

using Kentico.Content.Web.Mvc.Routing;

using Microsoft.IdentityModel.Tokens;

namespace Kickstart.Web.Features.Navigation;

public class NavigationService : INavigationService
{
    private readonly IPreferredLanguageRetriever preferredLanguageRetriever;
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebsiteChannelContext webSiteChannelContext;



    public NavigationService(IPreferredLanguageRetriever preferredLanguageRetriever,
    IContentQueryExecutor contentQueryExecutor,
    IWebsiteChannelContext webSiteChannelContext)
    {
        this.preferredLanguageRetriever = preferredLanguageRetriever;
        this.contentQueryExecutor = contentQueryExecutor;
        this.webSiteChannelContext = webSiteChannelContext;
    }

    public async Task<NavigationItemViewModel> GetNavigationItemViewModel(NavigationItem navigationItem)
    {
        if (navigationItem?.NavigationItemTarget?.IsNullOrEmpty() ?? true)
        {
            return null;
        }

        var targetContentItemGuid = navigationItem.NavigationItemTarget.FirstOrDefault().SystemFields.ContentItemGUID;

        var builder = new ContentItemQueryBuilder();

        builder
            .ForContentType(LandingPage.CONTENT_TYPE_NAME, subqueryParameters => subqueryParameters
                .ForWebsite(webSiteChannelContext.WebsiteChannelName)
                .UrlPathColumns()
                .Where(where => where.WhereEquals(nameof(ContentItemFields.ContentItemGUID), targetContentItemGuid)))
            .InLanguage(preferredLanguageRetriever.Get());

        var targetLandingPage = (await contentQueryExecutor.GetMappedWebPageResult<LandingPage>(builder)).FirstOrDefault();

        var targetUrl = targetLandingPage.GetUrl();

        return new NavigationItemViewModel
        {
            Title = navigationItem.NavigationItemTitle,
            Url = targetUrl.RelativePath
        };
    }

    public async Task<NavigationMenuViewModel> GetNavigationMenuViewModel(NavigationMenu navigationMenu)
    {
        if (navigationMenu?.NavigationMenuItems?.IsNullOrEmpty() ?? true)
        {
            return null;
        }

        var menuItems = (await Task.WhenAll(navigationMenu.NavigationMenuItems.Select(GetNavigationItemViewModel)))
            .Where(x => x != null);

        return new NavigationMenuViewModel
        {
            Name = navigationMenu.NavigationMenuDisplayName,
            Items = menuItems
        };
    }
}
