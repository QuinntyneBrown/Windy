using System;
using System.Collections.Generic;

namespace Windy.Core.Entities
{
    public class OrderStatus
    {
        public Guid OrderStatusId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
