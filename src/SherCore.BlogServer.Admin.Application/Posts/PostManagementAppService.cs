using Microsoft.AspNetCore.Authorization;
using SherCore.BlogServer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PostWithDetailsDto> CreateAsync(CreatePostDto input)
        {
            var newPost = new Post(GuidGenerator.Create(), input.Title, input.IsReprint, input.CategoryId)
            {
                Content = input.Content,
                Status = input.Status,
            };

            await _postRepository.InsertAsync(newPost);

            return ObjectMapper.Map<Post, PostWithDetailsDto>(newPost);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<PostWithDetailsDto> GetAsync(Guid id)
        {
            var post = await _postRepository.FindAsync(id);

            return ObjectMapper.Map<Post, PostWithDetailsDto>(post);
        }

        public async Task<PagedResultDto<PostWithDetailsDto>> GetListAsync(PostQueryOption input)
        {
            var query = await _postRepository.GetQueryableAsync();

            query = query
                .WhereIf(!input.Title.IsNullOrEmpty(), x => x.Title.Contains(input.Title))
                .WhereIf(input.CategoryId.HasValue, x => x.CategoryId == input.CategoryId);

            var count = query.Count();
            var items = query.PageBy(input).ToList();

            var dtos = ObjectMapper.Map<List<Post>, List<PostWithDetailsDto>>(items);

            return new PagedResultDto<PostWithDetailsDto>
            {
                Items = dtos,
                TotalCount = count
            };
        }

        public Task<PostWithDetailsDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            throw new NotImplementedException();
        }
    }
}