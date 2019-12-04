using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class RealtiesRegionList
    {
        public int StateId { get; set; }
        public string StateSa { get; set; }
        public string StateName { get; set; }
        public int LocalityId { get; set; }
        public string LocalityName { get; set; }
        public int LocalityCount { get; set; }
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }
        public int? RealtyCount { get; set; }
    }
}
