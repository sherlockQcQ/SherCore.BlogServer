using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Comments
{
    public class Comment : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        ///  文章Id
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        ///  回复评论Id
        /// </summary>
        public Guid? RepliedCommentId { get; set; }

        /// <summary>
        ///  评论内容
        /// </summary>
        public string Content { get; set; }

        protected Comment()
        {
        }

        public Comment(Guid id, Guid postId, Guid? repliedCommentId, [NotNull] string content)
        {
            Id = id;
            PostId = postId;
            RepliedCommentId = repliedCommentId;
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        }

        /// <summary>
        ///  设置评论内容
        /// </summary>
        /// <param name="content"></param>
        public void SetContent(string content)
        {
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        }
    }
}