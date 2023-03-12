using SherCore.BlogServer.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SherCore.BlogServer.Blogs
{
    public class EfCoreBlogRepository : EfCoreRepository<BlogServerDbContext, Blog, Guid>, IBlogRepository
    {

        public EfCoreBlogRepository(IDbContextProvider<BlogServerDbContext> dbContextProvider)
            :base(dbContextProvider)
        {
           
        }

        public override Task<Blog> InsertAsync(Blog entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            entity.SetDescription();
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }
}
