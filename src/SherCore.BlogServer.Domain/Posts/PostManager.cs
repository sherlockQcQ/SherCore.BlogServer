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

        public async Task<Post> CreateAsync(Post newPost)
        {
            newPost.SetDescription();

            await _postRepository.InsertAsync(newPost);

            return newPost;
        }

        /// <summary>
        ///  根据PostId查找对应的Tag标签
        /// </summary>
        /// <param name="id">PostId</param>
        /// <returns></returns>
        public async Task<List<Tag>> GetTagsOfPostAsync(Guid id)
        {
            var tagIds = (await _postRepository.GetWithTagAsync(x=>x.Id==id)).Tags;

            return await _tagRepository.GetListAsync(tagIds.Select(t => t.TagId));
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

        /// <summary>
        ///  保存标签
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task SaveTags(ICollection<string> tags, Post post)
        {
            tags = tags
                .Distinct()
                .ToList();

            await RemoveOldTags(tags, post);
            await AddNewTags(tags, post);
        }

        /// <summary>
        /// 添加新标签
        /// </summary>
        /// <param name="newTags"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        private async Task AddNewTags(IEnumerable<string> newTags, Post post)
        {
            var tags = await _tagRepository.GetListAsync();

            foreach (var newTag in newTags)
            {
                var tag = tags.FirstOrDefault(t => t.Name == newTag);

                if (tag == null)
                {
                    tag = await _tagRepository.InsertAsync(new Tag(GuidGenerator.Create(), newTag, 1));
                }
                else
                {
                    tag.IncreaseUsageCount();
                    tag = await _tagRepository.UpdateAsync(tag);
                }

                post.AddTag(tag.Id);
            }
        }

        /// <summary>
        /// 移除老标签
        /// </summary>
        /// <param name="newTags"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        private async Task RemoveOldTags(ICollection<string> newTags, Post post)
        {
            foreach (var oldTag in post.Tags.ToList())
            {
                var tag = await _tagRepository.GetAsync(oldTag.TagId);

                var oldTagNameInNewTags = newTags.FirstOrDefault(t => t == tag.Name);

                if (oldTagNameInNewTags == null)
                {
                    post.RemoveTag(oldTag.TagId);

                    tag.DecreaseUsageCount();
                    await _tagRepository.UpdateAsync(tag);
                }
                else
                {
                    newTags.Remove(oldTagNameInNewTags);
                }
            }
        }
    }
}