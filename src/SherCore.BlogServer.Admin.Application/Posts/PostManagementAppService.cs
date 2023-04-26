using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SherCore.BlogServer.Admin.Tags;
using SherCore.BlogServer.Categorys;
using SherCore.BlogServer.Posts;
using SherCore.BlogServer.Tags;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace SherCore.BlogServer.Admin.Posts
{
    [Authorize()]
    [RemoteService(IsEnabled = false)]
    public class PostManagementAppService : AdminAppService, IPostManagementAppService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly PostManager _postManager;
        private readonly CategoryManager _categoryManager;

        public PostManagementAppService(
            IPostRepository postRepository,
            ITagRepository tagRepository,
            CategoryManager categoryManager,
            IRepository<IdentityUser, Guid> userRepository,
            PostManager postManager)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _categoryManager = categoryManager;
            _userRepository = userRepository;
            _postManager = postManager;
        }

        public async Task<PostWithDetailsDto> CreateAsync(CreatePostDto input)
        {
            var newPost = new Post(GuidGenerator.Create(), input.Title, input.IsReprint, input.CategoryId)
            {
                Content = input.Content,
                PublishDateTime = input.IsTiming ? input.PublishDateTime : DateTime.Now,
                IsTop = input.IsTop,
            };

            if (input.IsTiming)
            {
                newPost.Status = EnumStatus.Future;
                /*   todo?
                 *   1.创建发布任务。
                 *   2.邮件通知订阅。
                 */
            }

            newPost.SetDescription();
            var tagList = input.Tags.SplitByComma();
            await _postManager.SaveTags(tagList, newPost);

            return ObjectMapper.Map<Post, PostWithDetailsDto>(await _postManager.CreateAsync(newPost));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _postManager.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(List<Guid> ids)
        {
            if (!ids.Any())
            {
                throw new UserFriendlyException("选择的文章未找到！未删除文章！");
            }

            await _postManager.DeleteManyByIds(ids);
        }

        public async Task<PostWithDetailsDto> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);

            var dto = ObjectMapper.Map<Post, PostWithDetailsDto>(post);

            dto.Tags = ObjectMapper.Map<List<Tag>, List<TagDto>>(await _postManager.GetTagsOfPostAsync(id));

            return dto;
        }

        public async Task<PagedResultDto<PostWithDetailsDto>> GetListAsync(PostQueryOptionDto input)
        {
            var query = await _postManager.BuildIQueryable(
                ObjectMapper.Map<PostQueryOptionDto, PostQueryOption>(input));

            var count = await AsyncExecuter.CountAsync(query);
            var items = await AsyncExecuter
                .ToListAsync(query.PageBy(input).OrderBy(input.Sorting ?? "CreationTime Desc"));

            var dtoList = ObjectMapper.Map<List<Post>, List<PostWithDetailsDto>>(items);

            var names = await _categoryManager.LookupNameByIdAsync(dtoList.Select(x => x.CategoryId).Distinct()
                .ToArray());
            var userIds = dtoList.Select(x => x.CreatorId).Distinct().ToList();
            var users = await _userRepository.GetListAsync(x => userIds.Contains(x.Id)); // todo？扩展后需要重写

            dtoList.ForEach(dto =>
            {
                //如果删除分类时不删除文章// todo？扩展后需要重写
                dto.CategoryName = names.TryGetValue(dto.CategoryId, out string value) ? value : "已删除的分类专栏";
                dto.UserName = users.FirstOrDefault(x => x.Id == dto.CreatorId)?.UserName;
            });

            return new PagedResultDto<PostWithDetailsDto>
            {
                Items = dtoList,
                TotalCount = count
            };
        }

        public async Task<PostWithDetailsDto> UpdateAsync(Guid id, UpdatePostDto input)
        {
            var entity = await _postRepository.FindAsync(id);

            ObjectMapper.Map(entity, input);

            await _postRepository.UpdateAsync(entity);

            return ObjectMapper.Map<Post, PostWithDetailsDto>(entity);
        }
    }
}