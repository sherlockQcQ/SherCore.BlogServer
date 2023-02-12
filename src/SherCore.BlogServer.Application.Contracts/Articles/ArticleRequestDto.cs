using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Articles
{
    /// <summary>
    /// RequestDto -文章表查询条件
    /// </summary>
    public class ArticleRequestDto:PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }
}
