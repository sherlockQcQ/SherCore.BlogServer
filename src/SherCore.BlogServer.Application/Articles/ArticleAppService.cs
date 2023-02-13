using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Articles
{
    public class ArticleAppService : BlogServerAppService, IArticleAppService
    {
        private readonly IRepository<Article, Guid> _articleReository;

        public ArticleAppService(IRepository<Article, Guid> baseRepo)
        {
            _articleReository = baseRepo;
        }

        public async Task<ArticleDto> CreateAsync(ArticleCreateDto input)
        {
            var entity = ObjectMapper.Map<ArticleCreateDto, Article>(input);

            await _articleReository.InsertAsync(entity);

            return ObjectMapper.Map<Article, ArticleDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _articleReository.DeleteAsync(id);
        }

        public async Task<ArticleDto> GetAsync(Guid id)
        {
            var entity = await _articleReository.FindAsync(id);

            return ObjectMapper.Map<Article, ArticleDto>(entity);
        }

        public async Task<PagedResultDto<ArticleDto>> GetListAsync(ArticleRequestDto input)
        {
            var query = await BulidFiledQuery(ObjectMapper.Map<ArticleRequestDto, ArticleQueryOptionDto>(input));

            var list = query.PageBy(input).ToList();
            var totalCount = query.Count();

            return new PagedResultDto<ArticleDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Article>, List<ArticleDto>>(list)
            };
        }

        public async Task<ArticleDto> UpdateAsync(Guid id, ArticleUpdateDto input)
        {
            var entity = await _articleReository.GetAsync(id);

            ObjectMapper.Map(entity, input);

            await _articleReository.UpdateAsync(entity);

            return await GetAsync(id);
        }

        /// <summary>
        /// 查询条件构造
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task<IQueryable<Article>> BulidFiledQuery(ArticleQueryOptionDto input)
        {
            var query = await _articleReository.WithDetailsAsync(x => x.ArticleInfo);

            query = query
                   .WhereIf(input.Title.IsNullOrEmpty(), x => x.Titile.Contains(input.Title));///模糊查询

            return query;
        }
    }
}