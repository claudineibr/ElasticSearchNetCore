using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class LeadsGauge
    {
        public int Id { get; set; }
        public int? LeadTypeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
        public int? ContactTypeId { get; set; }
        public int? RealtyId { get; set; }
        public string Reference { get; set; }
        public string EventId { get; set; }
        [JsonIgnore]
        public DateTime? PublishedAt { get; set; }
        [JsonIgnore]
        public bool? HasOwner { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public int? UpdatedByUserId { get; set; }
        public int? CompanyId { get; set; }
        public int? UserServiceFormId { get; set; }
        public string SentEmails { get; set; }
        public string CellPhone { get; set; }
        public int? BrokerId { get; set; }
        public string LpsMidiaOrigem { get; set; }
        public bool? EvaluationRequested { get; set; }
        public int? ApplicationId { get; set; }
        public string PathTracker { get; set; }
        public string Endpoint { get; set; }

        public virtual Applications Application { get; set; }
        public virtual ContactTypes ContactType { get; set; }
        public virtual LeadTypes LeadType { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
    }
}
