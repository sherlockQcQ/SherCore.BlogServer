using System;
using System.Collections.Generic;

namespace SherCore.BlogServer.Posts
{
    public class PostQueryOption
    {
        /// <summary>
        ///  标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  分类Id
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        ///  状态
        /// </summary>
        public EnumStatus? Status { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        ///  结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///  分类专栏 -筛选器的条件
        /// </summary>
        public List<Guid> Category { get; set; } = new List<Guid>();

        /// <summary>
        ///  分类专栏 -筛选器的条件
        /// </summary>
        public List<Guid> Tag { get; set; } = new List<Guid>();
    }
}