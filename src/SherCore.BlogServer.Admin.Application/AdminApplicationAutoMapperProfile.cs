using AutoMapper;
using SherCore.BlogServer.Admin.Blogs;
using SherCore.BlogServer.Admin.Categorys;
using SherCore.BlogServer.Admin.Posts;
using SherCore.BlogServer.Blogs;
using SherCore.BlogServer.Categorys;
using SherCore.BlogServer.Posts;

namespace SherCore.BlogServer.Admin;

public class AdminApplicationAutoMapperProfile : Profile
{
    public AdminApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Blog,BlogDto>();

        CreateMap<Category, CategoryDto>();

        CreateMap<Post, PostWithDetailsDto>();
    }
}
