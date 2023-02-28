using System;
using System.Collections.Generic;
using System.Text;

namespace SherCore.BlogServer.Comments
{
    public class CommentCreateDto
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 父节点 -()
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>

        public int Status { get; set; }

        /// <summary>
        ///内容
        /// </summary>
        public string Content { get; set; }
    }
}