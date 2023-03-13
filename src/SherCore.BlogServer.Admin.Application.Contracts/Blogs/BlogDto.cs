using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SherCore.BlogServer.Admin.Blogs
{
    public class BlogDto
    {
        /// <summary>
        ///  标题
        /// </summary>
        public string Title { get; set; }

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

        /// <summary>
        /// 创建用户Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}