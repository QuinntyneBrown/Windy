using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windy.Core.Entities
{
    public class WorkOrder
    {
        [ForeignKey("Tenant")]
        public Guid TenantId { get; set; }
        public Guid WorkOrderId { get; set; }
		public string Name { get; set; }
        public WorkOrderStatus Status { get; set; }
    }
}
