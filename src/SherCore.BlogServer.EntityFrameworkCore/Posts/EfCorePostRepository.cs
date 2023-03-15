using Microsoft.EntityFrameworkCore;
using SherCore.BlogServer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<List<Post>> GetListByStatusAsync(EnumStatus enumStatus, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).Where(t => t.Status == enumStatus)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<IQueryable<Post>> GetQueryableByStatusAsync(EnumStatus enumStatus)
        {
            return ((await GetDbSetAsync()).Where(t => t.Status == enumStatus));
        }

        public async Task<int> GetPostCountOfCategory(Guid category, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).Where(t => t.CategoryId == category)
                 .CountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Dictionary<Guid, int>> GetPostCountOfCategory(Guid[] categoryIds)
        {
            var query = (await GetDbSetAsync()).Where(t => categoryIds.Contains(t.CategoryId));

            return query.GroupBy(i => i.CategoryId)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public async Task<IQueryable<Post>> BuildFieldQuery(EnumStatus? status, string title,
            bool? isTop)
        {
            var query = await GetQueryableAsync();

            query = query
                .WhereIf(status.HasValue, x => x.Status == status)
                .WhereIf(!title.IsNullOrEmpty(), x => x.Title.Contains(title))
                .WhereIf(isTop.HasValue, x => x.IsTop);

            return query;
        }
    }
}