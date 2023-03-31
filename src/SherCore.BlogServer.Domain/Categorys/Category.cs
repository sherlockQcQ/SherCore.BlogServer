using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Categorys
{
    /// <summary>
    ///  专栏分类
    /// </summary>
    public class Category : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        ///  顺序
        /// </summary>
        public int Sort { get; set; }

        public Category()
        {
        }

        public Category(Guid id, string name, bool isEnable, int sort)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            IsEnable = isEnable;
            Sort = sort;
        }
    }
}