using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Categorys
{
    /*[Authorize()]*/
    /*[RemoteService(IsEnabled = false)]*/
    public class CategoryAppService
        :CrudAppService<Category,CategoryDto,Guid,CategoryRequestDto,CategoryCreateDto,CategoryUpdateDto>, ICategoryAppService
    {
        public CategoryAppService(IRepository<Category,Guid> baseRepository) 
            :base(baseRepository)
        {
           
        }

    }
}
