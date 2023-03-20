using System.ComponentModel.DataAnnotations;

namespace SherCore.BlogServer.Posts
{
    public enum EnumStatus
    {
        /// <summary>
        /// 已发布-已发布的文章
        /// </summary>
        [Display(Name = "已发布")]
        Published = 0,

        /// <summary>
        /// 草稿-已保存但尚未完成且尚未发布的文章
        /// </summary>
        [Display(Name = "草稿箱")]
        Drafts = 1,

        /// <summary>
        /// 回收站-被添加到回收站的文章
        /// </summary>
        [Display(Name = "回收站")]
        Transh = 2,

        /// <summary>
        /// 定时发布-计划稍后定时发布的文章，
        /// </summary>
        [Display(Name = "定时发布")]
        Future = 3,

        /// <summary>
        /// 私有-标记为私密的文章，只有自己登录后可见
        /// </summary>
        [Display(Name = "仅自己可见")]
        Private = 4,
    }
}