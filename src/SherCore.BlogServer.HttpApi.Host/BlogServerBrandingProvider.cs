using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SherCore.BlogServer;

[Dependency(ReplaceServices = true)]
public class BlogServerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlogServer";
}
