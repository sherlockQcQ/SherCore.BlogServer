using System.Threading.Tasks;

namespace SherCore.BlogServer.Data;

public interface IBlogServerDbSchemaMigrator
{
    Task MigrateAsync();
}
