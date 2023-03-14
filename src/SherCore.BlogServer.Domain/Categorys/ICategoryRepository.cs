using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Categorys
{
    public interface ICategoryRepository : IBasicRepository<Category, Guid>
    {
        Task<IQueryable<Category>> BuildFieldQuery();
    }
}