using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class UserApplications
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public int? CompanyId { get; set; }
        public int? CompanyGroupId { get; set; }
        public int? Permissions { get; set; }
        public int? StateId { get; set; }
        public int? LocalityId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedByUserId { get; set; }
        public int? StakeHolderId { get; set; }

        public virtual Applications Application { get; set; }
        public virtual CompanyGroups CompanyGroup { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual Stakeholders StakeHolder { get; set; }
        public virtual States State { get; set; }
        public virtual Users UpdatedByUser { get; set; }
        public virtual Users User { get; set; }
    }
}
