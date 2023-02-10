using System;
using System.Collections.Generic;
using System.Text;
using SherCore.BlogServer.Localization;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer;

/* Inherit your application services from this class.
 */

public abstract class BlogServerAppService : ApplicationService
{
    protected BlogServerAppService()
    {
        LocalizationResource = typeof(BlogServerResource);
    }
}