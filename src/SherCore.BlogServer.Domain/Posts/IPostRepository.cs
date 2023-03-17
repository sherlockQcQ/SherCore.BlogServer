using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Posts
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetListByStatusAsync(EnumStatus enumStatus, CancellationToken cancellationToken = default);

        Task<int> GetPostCountOfCategory(Guid category, CancellationToken cancellationToken = default);

        Task<Dictionary<Guid, int>> GetPostCountOfCategory(Guid[] categoryIds);
    }
}