using System;
using System.Collections.Generic;

namespace ElasticSearch.Domain.Classes
{
    public partial class ContactUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telephone { get; set; }
        public int? StateId { get; set; }
        public int? LocalityId { get; set; }
        public int? RealtyId { get; set; }
        public int ApplicationId { get; set; }
        public int ContactUsTypeId { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Message { get; set; }
        public int? ContactTypeId { get; set; }

        public virtual Applications Application { get; set; }
        public virtual Localities Locality { get; set; }
        public virtual Realties Realty { get; set; }
        public virtual States State { get; set; }
    }
}
