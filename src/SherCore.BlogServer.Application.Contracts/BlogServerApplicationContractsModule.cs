using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(BlogServerDomainSharedModule),
    /*typeof(AbpAccountApplicationContractsModule),*/
    typeof(AbpFeatureManagementApplicationContractsModule),
    /*typeof(AbpIdentityApplicationContractsModule),*/
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    /*typeof(AbpTenantManagementApplicationContractsModule),*/
    typeof(AbpObjectExtendingModule)
)]
public class BlogServerApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        BlogServerDtoExtensions.Configure();
    }
}
