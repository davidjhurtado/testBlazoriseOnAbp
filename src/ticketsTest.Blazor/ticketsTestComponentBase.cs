using ticketsTest.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ticketsTest.Blazor
{
    public abstract class ticketsTestComponentBase : AbpComponentBase
    {
        protected ticketsTestComponentBase()
        {
            LocalizationResource = typeof(ticketsTestResource);
        }
    }
}
