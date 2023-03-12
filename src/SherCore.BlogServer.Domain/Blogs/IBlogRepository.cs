using System;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Blogs
{
    public interface IBlogRepository : IBasicRepository<Blog, Guid>
    {

    }
}
