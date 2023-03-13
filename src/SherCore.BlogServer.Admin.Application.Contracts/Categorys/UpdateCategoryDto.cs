using System;
using System.Collections.Generic;
using System.Text;

namespace SherCore.BlogServer.Admin.Categorys
{
    public class UpdateCategoryDto
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
    }
}