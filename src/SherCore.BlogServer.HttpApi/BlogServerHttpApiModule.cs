﻿using Localization.Resources.AbpUi;
using SherCore.BlogServer.Localization;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(BlogServerApplicationContractsModule),
  /*  typeof(AbpAccountHttpApiModule),*/
    /*typeof(AbpIdentityHttpApiModule),*/
    typeof(AbpPermissionManagementHttpApiModule),
    /*typeof(AbpTenantManagementHttpApiModule),*/
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class BlogServerHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BlogServerResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
