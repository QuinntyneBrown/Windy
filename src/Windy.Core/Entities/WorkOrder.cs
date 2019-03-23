using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class WorkOrder
    {
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Guid WorkOrderId { get; set; }
        [ForeignKey("Status")]
        public Guid WorkOrderStatusId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float Amount { get; set; }
        public Company Company { get; set; }
        public WorkOrderStatus Status { get; set; }
    }
}
