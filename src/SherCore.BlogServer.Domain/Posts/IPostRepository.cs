using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Posts
{
    public interface IPostRepository : IBasicRepository<Post, Guid>
    {
        Task<List<Post>> GetListByStatusAsync(EnumStatus enumStatus, CancellationToken cancellationToken = default);

        Task<IQueryable<Post>> GetQueryableByStatusAsync(EnumStatus enumStatus);

        Task<int> GetPostCountOfCategory(Guid category, CancellationToken cancellationToken = default);

        Task<Dictionary<Guid, int>> GetPostCountOfCategory(Guid[] categoryIds);

        Task<IQueryable<Post>> BuildFieldQuery(EnumStatus? status, string title,bool? isTop);
    }
}