using SherCore.BlogServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SherCore.BlogServer.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BlogServerEntityFrameworkCoreModule),
    typeof(BlogServerApplicationContractsModule)
    )]
public class BlogServerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
