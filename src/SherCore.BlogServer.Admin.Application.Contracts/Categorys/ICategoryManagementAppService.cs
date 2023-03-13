using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Categorys
{
    public interface ICategoryManagementAppService : ICrudAppService<CategoryDto, Guid, CategoryQueryOption, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}