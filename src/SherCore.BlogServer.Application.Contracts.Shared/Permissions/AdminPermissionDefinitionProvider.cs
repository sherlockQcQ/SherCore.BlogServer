using SherCore.BlogServer;
using SherCore.BlogServer.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SherCore.BlogServer.Permissions;

public class AdminPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdminPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AdminPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogServerResource>(name);
    }
}
