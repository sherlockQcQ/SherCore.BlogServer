using SherCore.BlogServer.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SherCore.BlogServer.Tags
{
    public class EfCoreTagRepository : EfCoreRepository<BlogServerDbContext, Tag, Guid>, ITagRepository
    {
        public EfCoreTagRepository(IDbContextProvider<BlogServerDbContext> dbContextProvider)
             : base(dbContextProvider)
        {
        }
    }
}