using SherCore.BlogServer.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SherCore.BlogServer.Posts
{
    public class EfCorePostRepository : EfCoreRepository<BlogServerDbContext, Post, Guid>, IPostRepository
    {
        public EfCorePostRepository(IDbContextProvider<BlogServerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}