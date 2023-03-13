using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Categorys
{
    public class CategoryDto : EntityDto<Guid>
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

        #region 扩展字段

        /// <summary>
        /// 分类下文章总数
        /// </summary>
        public int Count { get; set; }

        #endregion 扩展字段
    }
}