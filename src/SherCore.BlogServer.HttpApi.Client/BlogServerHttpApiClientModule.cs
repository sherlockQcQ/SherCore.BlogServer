﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace SherCore.BlogServer;

[DependsOn(
    typeof(BlogServerApplicationContractsModule),
/*    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),*/
    typeof(AbpPermissionManagementHttpApiClientModule),
    /*typeof(AbpTenantManagementHttpApiClientModule),*/
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class BlogServerHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BlogServerApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BlogServerHttpApiClientModule>();
        });
    }
}
