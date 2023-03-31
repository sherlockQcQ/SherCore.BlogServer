using SherCore.BlogServer.Posts;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Posts
{
    public class PostQueryOptionDto : PagedAndSortedResultRequestDto
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
        ///  分类专栏 -筛选器的条件
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        ///  分类专栏 -筛选器的条件
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        ///  结束日期
        /// </summary>
        public DateTime? EndDate { get; set;}
    }
}