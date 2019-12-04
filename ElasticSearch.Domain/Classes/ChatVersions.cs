using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class ChatVersions
    {
        public ChatVersions()
        {
            ContactChannels = new HashSet<ContactChannels>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        public string EndPoint { get; set; }

        [JsonIgnore]
        public virtual ICollection<ContactChannels> ContactChannels { get; set; }
    }
}
