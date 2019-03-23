using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class Customer
    {
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }

    }
}
