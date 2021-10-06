using ticketsTest.Localization;
using Volo.Abp.Application.Services;

namespace ticketsTest
{
    /* Inherit your application services from this class.
     */
    public abstract class ticketsTestAppService : ApplicationService
    {
        protected ticketsTestAppService()
        {
            LocalizationResource = typeof(ticketsTestResource);
        }
    }
}
