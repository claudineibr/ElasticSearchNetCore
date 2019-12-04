using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class Schools
    {
        public int Id { get; set; }
        public int SchoolTypeId { get; set; }
        public int SchoolCategoryId { get; set; }
        public int SchoolCategoryTypeId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int LocalityId { get; set; }
        public int StateId { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? ValueZoneId { get; set; }
        public int? GeographicalZoneId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual GeographicalZones GeographicalZone { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual Neighborhoods Neighborhood { get; set; }
        public virtual SchoolCategories SchoolCategory { get; set; }
        public virtual SchoolCategoryTypes SchoolCategoryType { get; set; }
        public virtual SchoolTypes SchoolType { get; set; }
        public virtual States State { get; set; }
        public virtual Users UpdatedByUser { get; set; }
        public virtual ValueZones ValueZone { get; set; }
    }
}
