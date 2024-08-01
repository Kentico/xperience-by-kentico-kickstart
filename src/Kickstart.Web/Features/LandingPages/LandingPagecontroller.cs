using CMS.ContentEngine;
using CMS.Websites.Routing;
using CMS.Websites;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;
using Kickstart;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

[assembly: RegisterWebPageRoute(
    contentTypeName: LandingPage.CONTENT_TYPE_NAME,
    controllerType: typeof(Kickstart.Web.Features.LandingPages.LandingPageController))]

namespace Kickstart.Web.Features.LandingPages;
public class LandingPageController : Controller
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageDataContextRetriever webPageDataContextRetriever;
    private readonly IWebsiteChannelContext webSiteChannelContext;
    private readonly IPreferredLanguageRetriever preferredLanguageRetriever;

    public LandingPageController(
        IContentQueryExecutor contentQueryExecutor,
        IWebPageDataContextRetriever webPageDataContextRetriever,
        IWebsiteChannelContext webSiteChannelContext,
        IPreferredLanguageRetriever preferredLanguageRetriever)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageDataContextRetriever = webPageDataContextRetriever;
        this.webSiteChannelContext = webSiteChannelContext;
        this.preferredLanguageRetriever = preferredLanguageRetriever;
    }

    public async Task<IActionResult> Index()
    {
        var context = webPageDataContextRetriever.Retrieve();
        var builder = new ContentItemQueryBuilder()
                            .ForContentType(
                                LandingPage.CONTENT_TYPE_NAME,
                                config => config
                                    .Where(where => where.WhereEquals(nameof(WebPageFields.WebPageItemID), context.WebPage.WebPageItemID))
                                    .WithLinkedItems(1)
                                    .ForWebsite(webSiteChannelContext.WebsiteChannelName)
                                )
                            .InLanguage(preferredLanguageRetriever.Get());

        IEnumerable<LandingPage> pages = await contentQueryExecutor.GetMappedWebPageResult<LandingPage>(builder);

        var model = LandingPageViewModel.GetViewModel(pages.FirstOrDefault());
        return new TemplateResult(model);
    }
}