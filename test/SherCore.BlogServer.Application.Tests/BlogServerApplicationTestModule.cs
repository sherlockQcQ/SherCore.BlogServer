using Volo.Abp.Modularity;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(BlogServerApplicationModule),
    typeof(BlogServerDomainTestModule)
    )]
public class BlogServerApplicationTestModule : AbpModule
{

}
