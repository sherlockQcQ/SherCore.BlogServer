using SherCore.BlogServer.EntityFrameworkCore;
using System;
using System.Linq;
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
    }
}