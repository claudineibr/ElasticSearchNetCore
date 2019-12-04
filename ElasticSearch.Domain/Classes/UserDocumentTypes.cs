using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class UserDocumentTypes
    {
        public UserDocumentTypes()
        {
            UserAttachments = new HashSet<UserAttachments>();
            UserDocuments = new HashSet<UserDocuments>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<UserAttachments> UserAttachments { get; set; }
        public virtual ICollection<UserDocuments> UserDocuments { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
