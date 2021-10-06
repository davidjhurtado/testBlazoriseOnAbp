using ticketsTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ticketsTest.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ticketsTestController : AbpController
    {
        protected ticketsTestController()
        {
            LocalizationResource = typeof(ticketsTestResource);
        }
    }
}