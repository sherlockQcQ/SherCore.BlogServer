using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Categorys
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<IQueryable<Category>> BuildFieldQuery(string name);
    }
}