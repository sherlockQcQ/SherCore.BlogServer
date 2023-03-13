using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Blogs
{
    public interface IBlogManagementAppService:IApplicationService
    {
        Task<BlogDto> CreateAsync(CreateBlogDto input);

        Task<PagedResultDto<BlogDto>> GetListAsync();

        Task DeleteAsync(Guid id);
    }
}
