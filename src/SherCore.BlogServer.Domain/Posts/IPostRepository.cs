using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Posts
{
    public interface IPostRepository : IBasicRepository<Post, Guid>
    {
    }
}