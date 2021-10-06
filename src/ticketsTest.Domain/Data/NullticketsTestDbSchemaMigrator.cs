using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ticketsTest.Data
{
    /* This is used if database provider does't define
     * IticketsTestDbSchemaMigrator implementation.
     */
    public class NullticketsTestDbSchemaMigrator : IticketsTestDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}