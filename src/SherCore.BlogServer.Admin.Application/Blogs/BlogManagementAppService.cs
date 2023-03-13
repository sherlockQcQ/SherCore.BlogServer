using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SherCore.BlogServer.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace SherCore.BlogServer.Admin.Blogs
{
    [Authorize]
    public class BlogManagementAppService : AdminAppService, IBlogManagementAppService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogManagementAppService(
            IBlogRepository blogRepository,
            UserManager<IdentityUser> userManager)
        {
            _blogRepository = blogRepository;
            _userManager = userManager;
        }

        public async Task<BlogDto> CreateAsync(CreateBlogDto input)
        {
            var newBlog = new Blog(GuidGenerator.Create(), input.Title, input.Content);

            newBlog = await _blogRepository.InsertAsync(newBlog);

            return ObjectMapper.Map<Blog, BlogDto>(newBlog);
        }

        public async Task<PagedResultDto<BlogDto>> GetListAsync()
        {
            var blogs = await _blogRepository.GetListAsync();

            var items = new List<BlogDto>(ObjectMapper.Map<List<Blog>, List<BlogDto>>(blogs));
            var userIds = items.Select(x => x.CreatorId).Distinct().ToList();

            /*            var users = _userManager.Users.Where(x => userIds.Contains(x.Id)).ToList();

                        items.ForEach(t =>
                        {
                            t.CreatorName = users.FirstOrDefault(x => x.Id == t.CreatorId).UserName;
                        });*/

            return new PagedResultDto<BlogDto>
            {
                Items = items,
                TotalCount = blogs.Count
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _blogRepository.DeleteAsync(id);
        }
    }
}