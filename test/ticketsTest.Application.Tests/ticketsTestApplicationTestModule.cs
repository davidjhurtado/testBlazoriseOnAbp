using Volo.Abp.Modularity;

namespace ticketsTest
{
    [DependsOn(
        typeof(ticketsTestApplicationModule),
        typeof(ticketsTestDomainTestModule)
        )]
    public class ticketsTestApplicationTestModule : AbpModule
    {

    }
}