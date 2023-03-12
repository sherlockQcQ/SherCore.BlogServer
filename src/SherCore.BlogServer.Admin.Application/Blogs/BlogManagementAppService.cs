using SherCore.BlogServer.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherCore.BlogServer.Admin.Blogs
{
    public class BlogManagementAppService:AdminAppService,IBlogManagementAppService
    {
        public readonly IBlogRepository _blogRepository;

        public BlogManagementAppService(
            IBlogRepository blogRepository) 
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogDto> CreateAsync(CreateBlogDto input)
        {
            var newBlog = new Blog(GuidGenerator.Create(), input.Title, input.Content)
            {
                Content = input.Content
            };

            newBlog = await _blogRepository.InsertAsync(newBlog);

            return ObjectMapper.Map<Blog, BlogDto>(newBlog);
        }
    }
}
