using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace SherCore.BlogServer.Categorys
{
    public class CategoryDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;

        public CategoryDataSeedContributor(
            IRepository<Category, Guid> categrotyRepository,
            ICurrentTenant currentTenant,
            IGuidGenerator guidGenerator)
        {
            _categoryRepository = categrotyRepository;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                if (await _categoryRepository.GetCountAsync() > 0)
                {
                    return;
                }

                int sort = 0;

                await _categoryRepository.InsertAsync(new Category(
                     id: _guidGenerator.Create(),
                     name: "编程算法",
                     isEnable: true,
                     sort: ++sort
                 ),
                 autoSave: true);

                await _categoryRepository.InsertAsync(new Category(
                    id: _guidGenerator.Create(),
                    name: "随笔",
                    isEnable: true,
                    sort: ++sort
                ),
                autoSave: true);

                await _categoryRepository.InsertAsync(new Category(
                    id: _guidGenerator.Create(),
                    name: "运维笔记",
                    isEnable: true,
                    sort: ++sort
                ),
                autoSave: true);

                await _categoryRepository.InsertAsync(new Category(
                    id: _guidGenerator.Create(),
                    name: "脚本工具",
                    isEnable: true,
                    sort: ++sort
                ),
                autoSave: true);

                await _categoryRepository.InsertAsync(new Category(
                    id: _guidGenerator.Create(),
                    name: "关于本站",
                    isEnable: true,
                    sort: ++sort
                    ),
                    autoSave: true);
            }
        }
    }
}