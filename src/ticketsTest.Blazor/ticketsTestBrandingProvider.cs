using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ticketsTest.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class ticketsTestBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ticketsTest";
    }
}
