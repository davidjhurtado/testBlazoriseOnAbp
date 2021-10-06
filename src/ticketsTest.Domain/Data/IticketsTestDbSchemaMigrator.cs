using System.Threading.Tasks;

namespace ticketsTest.Data
{
    public interface IticketsTestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}