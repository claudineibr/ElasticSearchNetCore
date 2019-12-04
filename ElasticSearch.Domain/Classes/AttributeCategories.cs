using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class AttributeCategories
    {
        public AttributeCategories()
        {
            Attributes = new HashSet<Attributes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Attributes> Attributes { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
