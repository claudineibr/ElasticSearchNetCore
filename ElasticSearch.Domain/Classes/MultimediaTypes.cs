using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class MultimediaTypes
    {
        public MultimediaTypes()
        {
            MultimediaSubTypes = new HashSet<MultimediaSubTypes>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<MultimediaSubTypes> MultimediaSubTypes { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
