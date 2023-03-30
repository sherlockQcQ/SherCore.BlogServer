using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Tags
{
    public class TagQueryOption : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }
}