using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.FirendLinks
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class FirendLink : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 图标
        /// </summary>

        public string Avater { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}