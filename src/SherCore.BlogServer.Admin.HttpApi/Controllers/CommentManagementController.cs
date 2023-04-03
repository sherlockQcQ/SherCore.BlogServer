using Microsoft.AspNetCore.Mvc;
using SherCore.BlogServer.Admin.Comments;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Controllers
{
    [RemoteService]
    [Area("admin")]
    [Route("api/comment/management")]
    public class CommentManagementController : AdminController, ICommentManagementAppService
    {
        private readonly ICommentManagementAppService _appService;

        public CommentManagementController(
            ICommentManagementAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public Task<CommentDto> CreateAsync(CreateCommentDto input)
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
        [Route("{id}")]
        public Task<CommentDto> GetAsync(Guid id)
        {
            return _appService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CommentDto>> GetListAsync(CommentQueryOptionDto input)
        {
            return _appService.GetListAsync(input);
        }

        [HttpPut]
        [HttpPost]
        [Route("{id}")]
        public Task<CommentDto> UpdateAsync(Guid id, UpdateCommentDto input)
        {
            return _appService.UpdateAsync(id, input);
        }
    }
}