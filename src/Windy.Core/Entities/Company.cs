using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ICollection<Employee> Employees { get; set; }
            = new HashSet<Employee>();
    }
}
