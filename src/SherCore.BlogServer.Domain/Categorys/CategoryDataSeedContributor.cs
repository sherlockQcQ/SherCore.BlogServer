using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace SherCore.BlogServer.Categorys;

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

            var sort = 0;

            await _categoryRepository.InsertAsync(new Category(
                    _guidGenerator.Create(),
                    "编程算法",
                    true,
                    ++sort
                ),
                true);

            await _categoryRepository.InsertAsync(new Category(
                    _guidGenerator.Create(),
                    "随笔",
                    true,
                    ++sort
                ),
                true);

            await _categoryRepository.InsertAsync(new Category(
                    _guidGenerator.Create(),
                    "运维笔记",
                    true,
                    ++sort
                ),
                true);

            await _categoryRepository.InsertAsync(new Category(
                    _guidGenerator.Create(),
                    "脚本工具",
                    true,
                    ++sort
                ),
                true);

            await _categoryRepository.InsertAsync(new Category(
                    _guidGenerator.Create(),
                    "关于本站",
                    true,
                    ++sort
                ),
                true);
        }
    }
}