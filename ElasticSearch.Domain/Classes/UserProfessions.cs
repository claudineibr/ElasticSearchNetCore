using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class UserProfessions
    {
        public UserProfessions()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Users> Users { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
