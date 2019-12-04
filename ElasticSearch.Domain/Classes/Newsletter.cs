using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class Newsletter
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool OptOut { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
