using SherCore.BlogServer.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SherCore.BlogServer.Comments
{
    public class EfCoreCommentRepository : EfCoreRepository<BlogServerDbContext, Comment, Guid>, ICommentRepository
    {
        public EfCoreCommentRepository(IDbContextProvider<BlogServerDbContext> dbContextProvider)
            :base(dbContextProvider)
        {

        }

    }
}
