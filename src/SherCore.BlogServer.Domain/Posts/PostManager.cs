using System;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Threading.Tasks;

namespace SherCore.BlogServer.Posts
{
    public class PostManager : DomainService
    {
        private readonly IPostRepository _postRepository;
        private readonly IRepository<PostTag> _postTagrepository;

        public PostManager(
            IPostRepository postRepository,
            IRepository<PostTag> postTagRepository)
        {
            _postRepository = postRepository;
            _postTagrepository = postTagRepository;
        }

        /// <summary>
        ///  构造查询IQuery语句
        /// </summary>
        /// <param name="option">查询条件</param>
        /// <returns></returns>
        public async Task<IQueryable<Post>> BuildIQueryable(PostQueryOption option)
        {
            var queryable = await _postRepository.GetQueryableAsync();

            queryable = queryable
                 .WhereIf(!option.Title.IsNullOrEmpty(), x => x.Title.Contains(option.Title))
                 .WhereIf(option.Category.Any(), x => option.Category.Contains(x.CategoryId))
                 .WhereIf(option.StartDate.HasValue,x=>x.PublishDateTime>=option.StartDate)
                 .WhereIf(option.EndDate.HasValue,x=>x.PublishDateTime<=option.EndDate)
                 .WhereIf(option.Status.HasValue, x => x.Status == option.Status);

            if (option.Tag.Any())
            {
                var postTagQuery = await _postTagrepository.GetQueryableAsync();

                var postIds = await AsyncExecuter
                      .ToListAsync(postTagQuery.Where(x => option.Tag.Contains(x.TagId)).Select(x => x.PostId).Distinct());

                queryable = queryable.Where(x => postIds.Contains(x.Id));
            }

            return queryable;
        }
    }
}