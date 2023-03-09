using System;
using System.Collections.Generic;
using System.Text;
using SherCore.BlogServer.Localization;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin;

/* Inherit your application services from this class.
 */
public abstract class AdminAppService : ApplicationService
{
    protected AdminAppService()
    {
        LocalizationResource = typeof(BlogServerResource);
    }
}
