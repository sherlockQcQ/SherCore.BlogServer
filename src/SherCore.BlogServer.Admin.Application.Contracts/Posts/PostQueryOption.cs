using SherCore.BlogServer.Posts;
using System;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Posts
{
    public class PostQueryOption : PagedAndSortedResultRequestDto
    {
        public string Title { get; set; }

        public Guid? CategoryId { get; set; }

        public EnumStatus? Status { get; set; }

        public Guid? TagId { get; set; }
    }
}