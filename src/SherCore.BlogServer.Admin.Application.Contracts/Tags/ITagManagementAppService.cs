using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Tags
{
    public interface ITagManagementAppService : IApplicationService
    {
        Task<List<TagDto>> LookUpAll(TagQueryOption input);
    }
}