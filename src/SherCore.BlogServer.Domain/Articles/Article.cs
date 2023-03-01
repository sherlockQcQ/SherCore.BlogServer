using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Articles
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class Article : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Titile { get; set; }

        /// <summary>
        ///概要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 页面访问量
        /// </summary>
        public int PageView { get; set; }

        /// <summary>
        /// 评论量
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 赞同数
        /// </summary>
        public int ThumbUp { get; set; }

        /// <summary>
        /// 状态  -1、公开 -2、私密 -3、草稿
        /// </summary>
        public ArticleStatus Status { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 是否转载
        /// </summary>
        public bool IsReprint { get; set; }

        /// <summary>
        /// 转载链接
        /// </summary>
        public string ReprintUrl { get; set; }

        /// <summary>
        /// 文章详细Id
        /// </summary>
        public Guid ArticleInfoId { get; set; }

        public ArticleInfo ArticleInfo { get; set; }
    }
}