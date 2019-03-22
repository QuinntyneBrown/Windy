using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class Employee
    {
        [ForeignKey("Tenant")]
        public Guid TenantId { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public JobTitle JobTitle { get; set; }
        public ICollection<EmployeeWorkOrder> EmployeeWorkOrders { get; set; }
    }
}
