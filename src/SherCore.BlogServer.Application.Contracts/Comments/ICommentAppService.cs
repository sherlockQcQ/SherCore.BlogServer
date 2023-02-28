using SherCore.BlogServer.Articles;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Comments
{
    public interface ICommentAppService : ICrudAppService< //Defines CRUD methods
            CommentDto, //Used to show Entity
            Guid, //Primary key of the  entity
            CommentRequestDto, //Used for paging/sorting
            CommentCreateDto,
            CommentUpdateDto> //Used to create/update a entity
    {
    }
}