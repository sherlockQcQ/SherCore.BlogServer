using System;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Comments
{
    public interface ICommentManagementAppService : ICrudAppService<
        CommentDto,
        Guid,
        CommentQueryOptionDto,
        CreateCommentDto,
        UpdateCommentDto>
    {
    }
}