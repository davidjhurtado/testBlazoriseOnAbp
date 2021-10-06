using ticketsTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ticketsTest.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ticketsTestEntityFrameworkCoreModule),
        typeof(ticketsTestApplicationContractsModule)
    )]
    public class ticketsTestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
