using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class UserAttachments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserDocumentTypeId { get; set; }
        public string Description { get; set; }
        public DateTime DigitalizationDate { get; set; }
        public string FilePath { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Users UpdatedByUser { get; set; }
        public virtual UserDocumentTypes UserDocumentType { get; set; }
        public virtual Users User { get; set; }
    }
}
