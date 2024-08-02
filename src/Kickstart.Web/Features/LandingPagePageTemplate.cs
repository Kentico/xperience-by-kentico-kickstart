using Kentico.PageBuilder.Web.Mvc.PageTemplates;

using Kickstart;
using Kickstart.Web.Features.LandingPages;

[assembly: RegisterPageTemplate(
    identifier: LandingPagePageTemplate.IDENTIFIER,
    name: "Landing page content type template",
    customViewName: "~/Features/LandingPages/LandingPagePageTemplate.cshtml",
    ContentTypeNames = [LandingPage.CONTENT_TYPE_NAME],
    IconClass = "xp-market")]

namespace Kickstart.Web.Features.LandingPages;
public static class LandingPagePageTemplate
{
    public const string IDENTIFIER = "Kickstart.LandingPagePageTemplate";
}
