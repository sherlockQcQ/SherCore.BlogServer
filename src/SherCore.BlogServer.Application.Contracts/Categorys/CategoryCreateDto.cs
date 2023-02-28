using System;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Categorys
{
    public class CategoryCreateDto : EntityDto<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 分类下文章总数
        /// </summary>
        public int ArticleCount { get; set; }
    }
}