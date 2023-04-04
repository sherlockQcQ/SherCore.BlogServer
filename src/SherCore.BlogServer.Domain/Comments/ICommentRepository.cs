using System;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Comments
{
    public interface ICommentRepository:IRepository<Comment,Guid>
    {


    }
}
