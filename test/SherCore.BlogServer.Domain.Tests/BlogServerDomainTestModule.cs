using SherCore.BlogServer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(BlogServerEntityFrameworkCoreTestModule)
    )]
public class BlogServerDomainTestModule : AbpModule
{

}
