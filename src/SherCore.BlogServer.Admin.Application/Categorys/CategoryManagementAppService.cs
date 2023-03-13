using SherCore.BlogServer.Admin.Blogs;
using SherCore.BlogServer.Blogs;
using SherCore.BlogServer.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace SherCore.BlogServer.Admin.Categorys
{
    public class CategoryManagementAppService : AdminAppService, ICategoryManagementAppService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryManagementAppService(
            IRepository<Category, Guid> categoryRepository)
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

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.FindAsync(id);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryQueryOption input)
        {
            var query = await _categoryRepository.GetQueryableAsync();

            var items = query.PageBy(input).ToList();
            var count = query.Count();

            var dtos = new List<CategoryDto>(ObjectMapper.Map<List<Category>, List<CategoryDto>>(items));

            return new PagedResultDto<CategoryDto>()
            {
                Items = dtos,
                TotalCount = count
            };
        }

        public Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto input)
        {
            throw new NotImplementedException();
        }
    }
}