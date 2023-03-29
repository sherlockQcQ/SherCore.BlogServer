using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Posts
{
    public class Post : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
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

        /// <summary>
        ///  标签
        /// </summary>
        public ICollection<PostTag> Tags { get; set; }

        protected Post()
        {
        }

        public Post(Guid id, [NotNull] string title, bool isReprint, Guid categoryId)
        {
            Id = id;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            IsReprint = isReprint;
            CategoryId = categoryId;

            Tags = new Collection<PostTag>();
        }

        public Post IncreaseReadCount()
        {
            ReadCount++;
            return this;
        }

        public void AddTag(Guid tagId)
        {
            Tags.Add(new PostTag(Id, tagId));
        }

        public void RemoveTag(Guid tagId)
        {
            Tags.RemoveAll(t => t.TagId == tagId);
        }

        public void SetDescription()
        {
            Description = Content.Length >= 50 ? Content[..50] : Content;
        }
    }
}