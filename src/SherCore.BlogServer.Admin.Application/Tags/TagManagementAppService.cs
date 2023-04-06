using Microsoft.AspNetCore.Authorization;
using SherCore.BlogServer.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Admin.Tags
{
    [Authorize()]
    [RemoteService(IsEnabled = false)]
    public class TagManagementAppService : AdminAppService, ITagManagementAppService
    {
        private readonly IRepository<Tag, Guid> _repository;

        public TagManagementAppService(
            IRepository<Tag, Guid> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 查找所有标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<TagDto>> LookUpAll(TagQueryOption input)
        {
            var query = await _repository.GetQueryableAsync();

            query = query
                .Where(x => x.UsageCount != 0)
                .WhereIf(!input.Name.IsNullOrEmpty(), x => x.Name.Contains(input.Name))
                .OrderBy(input.Sorting?? "usageCount desc");

            var result = await AsyncExecuter
                 .ToListAsync(query.Select(x => ObjectMapper.Map<Tag, TagDto>(x)));

            return result;
        }
    }
}