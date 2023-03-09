using SherCore.BlogServer.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SherCore.BlogServer.Admin.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdminController : AbpControllerBase
{
    protected AdminController()
    {
        LocalizationResource = typeof(BlogServerResource);
    }
}
