using Microsoft.AspNetCore.Mvc;
using SherCore.BlogServer.Admin.Categorys;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Controllers
{
    [RemoteService]
    [Area("admin")]
    [Route("api/category/management")]
    public class CategoryManagementController:AdminController,ICategoryManagementAppService
    {
        private readonly ICategoryManagementAppService _appSerice;
        public CategoryManagementController(
            ICategoryManagementAppService appSerice)
        {
            _appSerice = appSerice;
        }

        [HttpPost]
        public Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            return _appSerice.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _appSerice.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CategoryDto> GetAsync(Guid id)
        {
            return _appSerice.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryQueryOption input)
        {
            return _appSerice.GetListAsync(input);
        }

        [HttpPut]
        [HttpPost]
        [Route("{id}")]
        public Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto input)
        {
            return _appSerice.UpdateAsync(id, input);
        }
    }
}
