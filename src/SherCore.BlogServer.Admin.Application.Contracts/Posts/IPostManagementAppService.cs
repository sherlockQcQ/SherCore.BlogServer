using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Posts
{
    public interface IPostManagementAppService : ICrudAppService<
        PostWithDetailsDto,
        Guid,
        PostQueryOptionDto,
        CreatePostDto,
        UpdatePostDto>
    {
        Task DeleteManyAsync(List<Guid> ids);
    }
}