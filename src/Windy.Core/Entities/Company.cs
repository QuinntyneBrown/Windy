using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class Company
    {
        [ForeignKey("Tenant")]
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
            = new HashSet<Employee>();
    }
}
