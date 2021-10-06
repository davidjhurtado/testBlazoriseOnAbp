using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ticketsTest.Data;
using Volo.Abp.DependencyInjection;

namespace ticketsTest.EntityFrameworkCore
{
    public class EntityFrameworkCoreticketsTestDbSchemaMigrator
        : IticketsTestDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreticketsTestDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ticketsTestDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ticketsTestDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
