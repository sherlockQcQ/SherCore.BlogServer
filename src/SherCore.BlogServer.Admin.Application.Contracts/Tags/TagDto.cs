using System;
using Volo.Abp.Application.Dtos;

namespace SherCore.BlogServer.Admin.Tags
{
    public class TagDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public int UsageCount { get; set; }

        public string Label
        {
            get
            {
                return $"{Name}({UsageCount})";
            }
            set { }
        }
    }
}