using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace SherCore.BlogServer.Categorys
{
    public class CategoryManager : DomainService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        /// <summary>
        ///  通过IDS集合查找对应分类专栏的名称
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<Dictionary<Guid, string>> LookupNameByIdAsync(Guid[] ids)
        {
            if (ids is null)
            {
                return null;
            }
            var query = await _categoryRepository.GetQueryableAsync();

            return query.Where(x => ids.Contains(x.Id)).ToDictionary(x => x.Id, x => x.Name);
        }

        /// <summary>
        ///  通过ID查找分类的Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> LookupNameByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return (await _categoryRepository.FindAsync(x => x.Id == id)).Name;
        }
    }
}
