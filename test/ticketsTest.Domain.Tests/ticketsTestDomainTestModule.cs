using ticketsTest.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ticketsTest
{
    [DependsOn(
        typeof(ticketsTestEntityFrameworkCoreTestModule)
        )]
    public class ticketsTestDomainTestModule : AbpModule
    {

    }
}