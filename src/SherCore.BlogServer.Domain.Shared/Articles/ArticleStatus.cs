using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SherCore.BlogServer.Articles
{
    /// <summary>
    /// 文章状态
    /// </summary>
    public enum ArticleStatus
    {
        [Display(Name ="公开")]
        Publish= 1,

        [Display(Name = "私密")]
        Private= 2,

        [Display(Name = "草稿")]
        Draft = 2,
    }
}
