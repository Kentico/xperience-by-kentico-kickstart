using System.Linq;

namespace Kickstart.Web.Features.LandingPages;

public class LandingPageViewModel
{
    public string Message { get; set; } = string.Empty;

    public static LandingPageViewModel GetViewModel(LandingPage landingPage) =>
        new()
        {
            Message = landingPage?.LandingPageSlogan.FirstOrDefault()?.SloganText ?? string.Empty
        };
}
