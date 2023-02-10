using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.IPDetails
{
    /// <summary>
    /// IP地址详细记录表
    /// </summary>
    public class IPDetail : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime LastTime { get; set; }

        /// <summary>
        /// 业务Id
        /// </summary>
        public string BussinessId { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BussinessType { get; set; }
    }
}