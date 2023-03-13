using System;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Categorys
{
    public interface ICategoryRepository : IBasicRepository<Category, Guid>
    {
    }
}