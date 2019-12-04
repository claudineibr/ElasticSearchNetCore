using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class WorkWithUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string TelephoneHome { get; set; }
        public string TelephoneMobile { get; set; }
        public int StateId { get; set; }
        public int LocalityId { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Education { get; set; }
        public int ApplicationId { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual Applications Application { get; set; }
        [JsonIgnore]
        public virtual Localities Locality { get; set; }
        [JsonIgnore]
        public virtual States State { get; set; }
    }
}
