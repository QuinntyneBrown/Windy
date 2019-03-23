using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class AssignedOrder
    {
        public Guid EmployeeId { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("Status")]
        public Guid AssignedOrderStatusId { get; set; }
        public AssignedOrderStatus Status { get; set; }

    }
}
