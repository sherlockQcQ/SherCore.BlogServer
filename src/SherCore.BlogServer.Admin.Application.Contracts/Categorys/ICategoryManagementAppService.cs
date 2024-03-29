﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Admin.Categorys
{
    public interface ICategoryManagementAppService : ICrudAppService<CategoryDto, Guid, CategoryQueryOption, CreateCategoryDto, UpdateCategoryDto>
    {
        Task DeleteManyAsync(List<Guid> ids);

        /// <summary>
        /// 专栏字段的下拉框数据
        /// </summary>
        /// <returns></returns>
        Task<List<CategorySelectDto>> GetSelectListAsync();
    }
}