using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class OperationTypes
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}
