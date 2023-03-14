﻿using Microsoft.AspNetCore.Authorization;
using SherCore.BlogServer.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Admin.Categorys
{
    [Authorize()]
    [RemoteService(IsEnabled = false)]
    public class CategoryManagementAppService : AdminAppService, ICategoryManagementAppService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManagementAppService(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            var category = new Category(
                id: GuidGenerator.Create(),
                name: input.Name,
                isEnable: input.IsEnable,
                sort: input.Sort);

            await _categoryRepository.InsertAsync(category);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<Guid> ids)
        {
            await _categoryRepository.DeleteManyAsync(ids);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.FindAsync(id);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryQueryOption input)
        {
            var query = await _categoryRepository.BuildFieldQuery();
            var items = query.PageBy(input).ToList();
            var count = query.Count();

            var dtos = new List<CategoryDto>(ObjectMapper.Map<List<Category>, List<CategoryDto>>(items));

            return new PagedResultDto<CategoryDto>()
            {
                Items = dtos,
                TotalCount = count
            };
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto input)
        {
            var entity = await _categoryRepository.FindAsync(id);

            entity.Sort = input.Sort;
            entity.IsEnable = input.IsEnable;
            entity.Name = input.Name;

            await _categoryRepository.UpdateAsync(entity);

            return await GetAsync(id);
        }
    }
}