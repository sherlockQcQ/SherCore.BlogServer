using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace SherCore.BlogServer.Comments
{
    public class CommentDto : EntityDto<Guid>
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

        /// <summary>
        /// 赞同数
        /// </summary>
        public int ThumbUp { get; set; }

        /// <summary>
        /// 反对数
        /// </summary>
        public int Oppse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        ///  创建者Id
        /// </summary>
        private Guid? CreatorId { get; set; }

        /// <summary>
        ///  用户名
        /// </summary>
        public string UserName { get; set; }
    }
}