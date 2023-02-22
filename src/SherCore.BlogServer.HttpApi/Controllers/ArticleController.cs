using Microsoft.AspNetCore.Mvc;
using SherCore.BlogServer.Articles;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Controllers
{
    /// <summary>
    ///  Api-文章
    /// </summary>
    [RemoteService]
    [Route("api/article")]
    public class ArticleController : BlogServerController, IArticleAppService
    {
        private readonly IArticleAppService _service;

        public ArticleController(IArticleAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public Task<ArticleDto> CreateAsync(ArticleCreateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleDto>> GetListAsync(ArticleRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPut]
        [HttpPost]
        [Route("{id}")]
        public Task<ArticleDto> UpdateAsync(Guid id, ArticleUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }
    }
}