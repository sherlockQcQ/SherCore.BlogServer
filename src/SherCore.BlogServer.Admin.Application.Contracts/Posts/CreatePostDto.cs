using SherCore.BlogServer.Posts;
using System;

namespace SherCore.BlogServer.Admin.Posts
{
    public class CreatePostDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否开启定时
        /// </summary>
        public bool IsTiming { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishDateTime { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImage { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        ///  是否转载
        /// </summary>
        public bool IsReprint { get; set; }

        /// <summary>
        ///  转载链接
        /// </summary>
        public string ReprintUrl { get; set; }

        /// <summary>
        ///  标签名称集合
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        ///  状态
        /// </summary>
        public EnumStatus Status { get; set; }
    }
}