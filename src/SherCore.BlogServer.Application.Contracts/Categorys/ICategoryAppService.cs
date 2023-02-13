using SherCore.BlogServer.Articles;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace SherCore.BlogServer.Categorys
{
    public interface ICategoryAppService : ICrudAppService< //Defines CRUD methods
            CategoryDto, //Used to show Entity
            Guid, //Primary key of the  entity
            CategoryRequestDto, //Used for paging/sorting
            CategoryCreateDto,
            CategoryUpdateDto> //Used to create/update a entity
    {

    }
}
