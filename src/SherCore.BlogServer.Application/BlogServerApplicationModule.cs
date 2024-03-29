﻿using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(BlogServerDomainModule),
    /*typeof(AbpAccountApplicationModule),*/
    typeof(BlogServerApplicationContractsModule),
    /*typeof(AbpIdentityApplicationModule),*/
    typeof(AbpPermissionManagementApplicationModule),
    /*typeof(AbpTenantManagementApplicationModule),*/
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class BlogServerApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BlogServerApplicationModule>();
        });
    }
}
