using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SherCore.BlogServer.Tags
{
    public class Tag : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int UsageCount { get; set; }

        protected Tag()
        {
        }

        public Tag(Guid id, [NotNull] string name, int usageCount = 0)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            UsageCount = usageCount;
        }

        public void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public void IncreaseUsageCount(int number = 1)
        {
            UsageCount += number;
        }

        public void DecreaseUsageCount(int number = 1)
        {
            if (UsageCount <= 0)
            {
                return;
            }

            if (UsageCount - number <= 0)
            {
                UsageCount = 0;
                return;
            }

            UsageCount -= number;
        }
    }
}