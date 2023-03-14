using Microsoft.AspNetCore.Authorization;
using SherCore.BlogServer.Posts;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Posts
{
    [Authorize()]
    [RemoteService(IsEnabled = false)]
    public class PostManagementAppService : AdminAppService, IPostManagementAppService
    {
        private readonly IPostRepository _postRepository;

        public PostManagementAppService(
            IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Task<PostWithDetailsDto> CreateAsync(CreatePostDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PostWithDetailsDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PostWithDetailsDto>> GetListAsync(PostQueryOption input)
        {
            throw new NotImplementedException();
        }

        public Task<PostWithDetailsDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            throw new NotImplementedException();
        }
    }
}