using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class AbTestVersions
    {
        public int Id { get; set; }
        public int AbTestId { get; set; }
        public string Description { get; set; }
        public int PageViews { get; set; }
        public int Conversions { get; set; }
        public bool VersionStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual AbTests AbTest { get; set; }
    }
}
