using Microsoft.AspNetCore.Mvc;
using SherCore.BlogServer.Admin.Blogs;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Controllers
{
    [RemoteService]
    [Area("admin")]
    [Route("api/blog/management")]
    public class BlogManagementController : AdminController, IBlogManagementAppService
    {
        private readonly IBlogManagementAppService _appService;

        public BlogManagementController(
            IBlogManagementAppService appService) 
        {
             _appService= appService;
        }

        [HttpPost]
        public Task<BlogDto> CreateAsync(CreateBlogDto input)
        {
            return _appService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _appService.DeleteAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<BlogDto>> GetListAsync()
        {
            return _appService.GetListAsync();
        }
    }
}
