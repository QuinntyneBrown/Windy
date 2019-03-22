using System;

namespace Windy.Core.Entities
{
    public class EmployeeWorkOrder
    {
        public Guid EmployeeId { get; set; }
        public Guid WorkOrderId { get; set; }
        public EmployeeWorkOrderStatus EmployeeWorkOrderStatus { get; set; }

    }
}
