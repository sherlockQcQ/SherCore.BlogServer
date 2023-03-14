using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Posts
{
    public class PostTag : CreationAuditedEntity
    {
        public Guid PostId { get; protected set; }

        public Guid TagId { get; protected set; }

        public PostTag(Guid postId, Guid tagId)
        {
            PostId = postId;
            TagId = tagId;
        }

        public override object[] GetKeys()
        {
            return new object[] { PostId, TagId };
        }
    }
}