using System;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Threading.Tasks;
using SherCore.BlogServer.Tags;

namespace SherCore.BlogServer.Posts
{
    public class PostManager : DomainService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IRepository<PostTag> _postTagrepository;

        public PostManager(
            IPostRepository postRepository,
            IRepository<PostTag> postTagRepository,
            ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _postTagrepository = postTagRepository;
            _tagRepository = tagRepository;
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
                 .WhereIf(option.StartDate.HasValue, x => x.PublishDateTime >= option.StartDate)
                 .WhereIf(option.EndDate.HasValue, x => x.PublishDateTime <= option.EndDate)
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

        /// <summary>
        ///  批量删除通过Ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task DeleteManyByIds(List<Guid> ids)
        {
            /*  你需要删除指定id的一组实体，使用DeleteMany方法可能并不是最优的选择。这是因为DeleteMany方法会在数据库中执行一条类似于
             *  "DELETE FROM Post WHERE Nums > 18"的SQL语句，这可能会影响到其他符合条件的实体。相比之下，使用Delete方法可以更加精确地删除指定id的实体，而不会影响到其他实体。
             *  在AbpVnext中，实体仓储接口中的Delete方法通常用于删除单个实体，而不是删除多个实体。因此，如果你需要删除一组指定id的实体，建议使用Delete方法，而不是DeleteMany方法。
             */
            foreach (var id in ids)
            {
                await DeleteAsync(id);
            }
        }

        /// <summary>
        ///  单个删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var post = await _postRepository.GetWithTagAsync(x => x.Id == id);

            var tagIds = post.Tags.Select(x => x.TagId).ToList();

            if (tagIds.Any())
            {
                await _tagRepository.UpdateDecreaseUsageCount(tagIds);
            }
            post.RemoveAllTag();
            await _postRepository.DeleteAsync(id);
        }
    }
}