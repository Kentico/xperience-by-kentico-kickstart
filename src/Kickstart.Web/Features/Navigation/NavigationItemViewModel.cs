using System.Linq;

using CMS.Websites;

namespace Kickstart.Web.Features.Navigation;

public class NavigationItemViewModel
{
    public string Title { get; set; }

    public string Url { get; set; }

    public static NavigationItemViewModel GetViewModel(NavigationItem navigationItem)
    {
        if (navigationItem?.NavigationItemTarget == null || !navigationItem.NavigationItemTarget.Any())
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
}
