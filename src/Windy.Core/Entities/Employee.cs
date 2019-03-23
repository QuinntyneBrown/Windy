using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class Employee
    {
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        [ForeignKey("Title")]
        public Guid JobTitleId { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public JobTitle Title { get; set; }
        public Company Company { get; set; }
        public ICollection<AssignedOrder> AssignedOrders { get; set; }
    }
}
