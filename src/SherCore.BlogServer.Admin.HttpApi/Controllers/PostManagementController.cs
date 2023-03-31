using Microsoft.AspNetCore.Mvc;
using SherCore.BlogServer.Admin.Posts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Controllers
{
    [RemoteService]
    [Area("admin")]
    [Route("api/post/management")]
    public class PostManagementController : AdminController, IPostManagementAppService
    {
        private readonly IPostManagementAppService _appService;

        public PostManagementController(
            IPostManagementAppService appSerive)
        {
            _appService = appSerive;
        }

        [HttpPost]
        public Task<PostWithDetailsDto> CreateAsync(CreatePostDto input)
        {
            return _appService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _appService.DeleteAsync(id);
        }

        [HttpDelete]
        public Task DeleteManyAsync([FromBody] List<Guid> ids)
        {
            return _appService.DeleteManyAsync(ids);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<PostWithDetailsDto> GetAsync(Guid id)
        {
            return _appService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<PostWithDetailsDto>> GetListAsync(PostQueryOptionDto input)
        {
            return _appService.GetListAsync(input);
        }

        [HttpPut]
        [HttpPost]
        [Route("{id}")]
        public Task<PostWithDetailsDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            return _appService.UpdateAsync(id, input);
        }
    }
}