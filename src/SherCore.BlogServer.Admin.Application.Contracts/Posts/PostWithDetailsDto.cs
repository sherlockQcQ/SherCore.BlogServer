using SherCore.BlogServer.Admin.Tags;
using SherCore.BlogServer.Posts;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Posts
{
    /// <summary>
    ///  详情表
    /// </summary>
    public class PostWithDetailsDto:EntityDto<Guid>
    {
        // <summary>
        ///  标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

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
        ///  阅读量
        /// </summary>
        public int ReadCount { get; set; }

        /// <summary>
        ///  赞同数
        /// </summary>
        public int ApprovalCount { get; set; }

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
        ///  状态
        /// </summary>
        public EnumStatus Status { get; set; }

        public List<TagDto> Tags { get; set; }=new List<TagDto>();

        #region 扩展字段

        /// <summary>
        ///  状态 Value值
        /// </summary>
        public string StatusValue => Status.GetDisplayName();

        /// <summary>
        ///  创建人Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        ///  创建人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///  创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>
        public string CategoryName { get; set; }

        #endregion 扩展字段
    }
}