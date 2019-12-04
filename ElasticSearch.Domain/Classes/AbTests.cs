using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class AbTests
    {
        public AbTests()
        {
            AbTestVersions = new HashSet<AbTestVersions>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool TestStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<AbTestVersions> AbTestVersions { get; set; }
    }
}
