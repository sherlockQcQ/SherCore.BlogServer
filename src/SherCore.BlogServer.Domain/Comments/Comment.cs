using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Comments
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class Comment : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>

        public int Status { get; set; }

        /// <summary>
        /// 文章Id
        /// </summary>

        public Guid ArticleId { get; set; }

        /// <summary>
        ///内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 赞同数
        /// </summary>
        public int ThumbUp { get; set; }

        /// <summary>
        /// 反对数
        /// </summary>
        public int Oppse { get; set; }
    }
}