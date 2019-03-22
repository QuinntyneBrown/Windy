using System;

namespace Windy.Core.Entities
{
    public class WorkOrderStatus
    {
        public Guid WorkOrderStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
