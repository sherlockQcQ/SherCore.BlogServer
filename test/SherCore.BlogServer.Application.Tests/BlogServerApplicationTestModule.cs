using SherCore.BlogServer.Admin;
using Volo.Abp.Modularity;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(AdminApplicationModule),
    typeof(BlogServerDomainTestModule)
    )]
public class BlogServerApplicationTestModule : AbpModule
{
}