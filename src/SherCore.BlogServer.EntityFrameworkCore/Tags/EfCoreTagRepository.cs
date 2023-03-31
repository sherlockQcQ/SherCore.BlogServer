using SherCore.BlogServer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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