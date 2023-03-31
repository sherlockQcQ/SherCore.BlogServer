using Microsoft.AspNetCore.Mvc;
using SherCore.BlogServer.Admin.Tags;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace SherCore.BlogServer.Admin.Controllers
{
    [RemoteService]
    [Area("admin")]
    [Route("api/tag/management")]
    public class TagManagementController : AdminController, ITagManagementAppService
    {
        private readonly ITagManagementAppService _appService;

        public TagManagementController(ITagManagementAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("lookup/all")]
        public Task<List<TagDto>> LookUpAll(TagQueryOption input)
        {
            return _appService.LookUpAll(input);
        }
    }
}