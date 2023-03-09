using SherCore.BlogServer.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SherCore.BlogServer.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlogServerController : AbpControllerBase
{
    protected BlogServerController()
    {
        LocalizationResource = typeof(BlogServerResource);
    }
}
