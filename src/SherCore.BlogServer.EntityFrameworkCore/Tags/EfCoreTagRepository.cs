using Microsoft.EntityFrameworkCore;
using SherCore.BlogServer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await(await GetDbSetAsync()).Where(t => ids.Contains(t.Id)).ToListAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        ///  更新标签 - Usage-1
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task UpdateDecreaseUsageCount(List<Guid> ids)
        {
            var tagList = await GetListAsync(x => ids.Contains(x.Id));

            tagList.ForEach(tag =>
            {
                tag.DecreaseUsageCount();
            });

            await UpdateManyAsync(tagList);
        }

    }
}