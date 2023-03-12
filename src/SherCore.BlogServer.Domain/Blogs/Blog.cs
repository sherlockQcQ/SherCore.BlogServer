using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Blogs
{
    public class Blog:FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        ///  标题
        /// </summary>
        [NotNull]
        public  string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///  浏览量
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        ///  赞同数
        /// </summary>
        public int ApprovalCount { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        ///  是否转载
        /// </summary>
        public bool IsReprint { get; set; }

        /// <summary>
        ///  转载链接
        /// </summary>
        public string ReprintUrl { get; set; }


        protected Blog() 
        {

        }

        public Blog(Guid id, string title, string content) 
        {
            Id = id;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        }

        public virtual Blog SetDescription() 
        {
            Check.NotNullOrEmpty(Content, nameof(Content));
            Description= Content[..100];

            return this;
        }
    }
}
