using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class BulkInsertSession
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
