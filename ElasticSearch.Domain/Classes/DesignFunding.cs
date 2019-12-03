using System;

namespace ElasticSearch.Domain.Classes
{
    public class DesignFunding
    {
        public int DesignUnitId { get; set; }
        public int DownPayment { get; set; }
        public int? FirstInstallment { get; set; }
        public int? LastInstallment { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual DesignUnits DesignUnit { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}