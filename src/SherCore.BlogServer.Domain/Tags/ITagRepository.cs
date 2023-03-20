using System;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Tags
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
    }
}