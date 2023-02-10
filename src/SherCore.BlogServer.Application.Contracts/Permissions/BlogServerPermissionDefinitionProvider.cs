using SherCore.BlogServer.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SherCore.BlogServer.Permissions;

public class BlogServerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BlogServerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlogServerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogServerResource>(name);
    }
}