using SherCore.BlogServer.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SherCore.BlogServer.Categorys
{
    public class EfCoreCategoryRepository : EfCoreRepository<BlogServerDbContext, Category, Guid>, ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<BlogServerDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
        }

        public async Task<IQueryable<Category>> BuildFieldQuery(string name)
        {
            var query = await GetQueryableAsync();

            query = query.WhereIf(!name.IsNullOrEmpty(), x => x.Name.Contains(name));

            return query;
        }
    }
}