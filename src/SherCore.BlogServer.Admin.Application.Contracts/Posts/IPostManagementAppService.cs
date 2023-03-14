using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Posts
{
    public interface IPostManagementAppService : ICrudAppService<
        PostWithDetailsDto,
        Guid,
        PostQueryOption,
        CreatePostDto,
        UpdatePostDto>
    {
    }
}