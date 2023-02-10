using System;
using Volo.Abp.Domain.Entities;

namespace SherCore.BlogServer.Articles
{
    public class ArticleInfo : Entity<Guid>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}