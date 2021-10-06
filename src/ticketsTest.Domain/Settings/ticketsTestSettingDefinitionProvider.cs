using Volo.Abp.Settings;

namespace ticketsTest.Settings
{
    public class ticketsTestSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ticketsTestSettings.MySetting1));
        }
    }
}
