using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Articles
{
    public interface IArticleAppService:ICrudAppService< //Defines CRUD methods
            ArticleDto, //Used to show Entity
            Guid, //Primary key of the  entity
            ArticleRequestDto, //Used for paging/sorting
            ArticleCreateOrUpdateDto> //Used to create/update a entity
    {

    }
}
