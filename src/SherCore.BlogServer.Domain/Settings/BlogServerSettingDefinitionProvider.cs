using Volo.Abp.Settings;

namespace SherCore.BlogServer.Settings;

public class BlogServerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BlogServerSettings.MySetting1));
    }
}
