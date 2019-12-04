using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    //public struct Location
    //{
    //    public double Longitude { get; set; }
    //    public double Latitude { get; set; }
    //}

    public partial class GeographicPositionFilter
    {
        public GeographicPositionFilter()
        {
        }

        public Int64 Id { get; set; }
        public Int64? NeighborhoodId { get; set; }
        public Int64? LocalityId { get; set; }
        public Int64 StateId { get; set; }
    }
}
