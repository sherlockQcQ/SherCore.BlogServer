using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Tags
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        /// <summary>
        ///  更新UsageCount (-1)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task UpdateDecreaseUsageCount(List<Guid> ids);

        Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}