using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class AssignedWorkOrder
    {
        public Guid EmployeeId { get; set; }
        public Guid WorkOrderId { get; set; }
        [ForeignKey("Status")]
        public Guid AssignedWorkOrderStatusId { get; set; }
        public AssignedWorkOrderStatus Status { get; set; }

    }
}
