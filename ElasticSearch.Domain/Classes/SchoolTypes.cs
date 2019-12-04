﻿using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class SchoolTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual Users UpdatedByUser { get; set; }
    }
}
