﻿using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class MultimediaSubTypes
    {
        public MultimediaSubTypes()
        {
            DesignUnitMultimedia = new HashSet<DesignUnitMultimedia>();
            DivisionMultimedia = new HashSet<DivisionMultimedia>();
            RealtyMultimedia = new HashSet<RealtyMultimedia>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int MultimediaTypeId { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<DesignUnitMultimedia> DesignUnitMultimedia { get; set; }
        public virtual ICollection<DivisionMultimedia> DivisionMultimedia { get; set; }
        public virtual ICollection<RealtyMultimedia> RealtyMultimedia { get; set; }
        public virtual MultimediaTypes MultimediaType { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
