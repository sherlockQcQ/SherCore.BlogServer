using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Categorys
{
    public class CategoryQueryOption : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }
}