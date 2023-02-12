using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Articles
{
    public class ArticleAppService : BlogServerAppService, IArticleAppService
    {
        private readonly IRepository<Article, Guid> _articleReository;
        public ArticleAppService(IRepository<Article,Guid> baseRepo)
        {
            _articleReository = baseRepo;
        }
        public async Task<ArticleDto> CreateAsync(ArticleCreateOrUpdateDto input)
        {
            var entity = ObjectMapper.Map<ArticleCreateOrUpdateDto, Article>(input);

            await _articleReository.InsertAsync(entity);

            return ObjectMapper.Map<Article, ArticleDto>(entity);

         }

        public async Task DeleteAsync(Guid id)
        {
           await _articleReository.DeleteAsync(id);
        }

        public  Task<ArticleDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ArticleDto>> GetListAsync(ArticleRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> UpdateAsync(Guid id, ArticleCreateOrUpdateDto input)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///  查询条件构造IQuery
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task<IQueryable<Article>> BulidFiledQuery(ArticleRequestDto input) 
        {
            var query =await _articleReository.GetQueryableAsync();

            query = query
                   .WhereIf(input.Title.IsNullOrEmpty(),x=>x.Titile.Contains(input.Title));///模糊查询

            return query;
        }
    }
}
