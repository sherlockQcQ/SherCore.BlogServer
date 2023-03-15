using System.ComponentModel.DataAnnotations;

namespace SherCore.BlogServer.Posts
{
    public enum EnumStatus
    {
        //已发布-已发布的文章
        [Display(Name = "已发布")]
        Published = 0,

        //草稿-已保存但尚未完成且尚未发布的文章
        [Display(Name = "草稿箱")]
        Drafts = 1,

        // 回收站-被添加到回收站的文章
        [Display(Name = "回收站")]
        Transh = 2,

        //定时发布-计划稍后定时发布的文章，
        [Display(Name = "定时发布")]
        Future = 3,

        //私有-标记为私密的文章，只有自己登录后可见
        [Display(Name = "仅自己可见")]
        Private = 4,
    }
}