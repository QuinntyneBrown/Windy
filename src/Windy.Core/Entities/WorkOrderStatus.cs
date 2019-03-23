using System;
using System.Collections.Generic;

namespace Windy.Core.Entities
{
    public class WorkOrderStatus
    {
        public Guid WorkOrderStatusId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
