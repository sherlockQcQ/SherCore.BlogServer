using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Categorys
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Category : FullAuditedAggregateRoot<Guid>
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
    }
}