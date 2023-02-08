using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SherCore.BlogServer.Data;

/* This is used if database provider does't define
 * IBlogServerDbSchemaMigrator implementation.
 */
public class NullBlogServerDbSchemaMigrator : IBlogServerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
