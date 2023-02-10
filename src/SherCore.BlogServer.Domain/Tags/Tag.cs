using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Tags
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Tag : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}