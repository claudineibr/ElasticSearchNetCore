using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public class CategoryTypes
    {
        public CategoryTypes()
        {
            DesignUnitCategoryTypes = new HashSet<DesignUnitCategoryTypes>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }

        [JsonIgnore]
        public virtual ICollection<DesignUnitCategoryTypes> DesignUnitCategoryTypes { get; set; }
        [JsonIgnore]
        public virtual Categories Category { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}