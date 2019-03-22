using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.WorkOrders
{
    public class WorkOrderDto
    {        
        public Guid WorkOrderId { get; set; }
        public string Name { get; set; }
    }

    public static class WorkOrderExtensions
    {        
        public static WorkOrderDto ToDto(this WorkOrder workOrder)
            => new WorkOrderDto
            {
                WorkOrderId = workOrder.WorkOrderId,
                Name = workOrder.Name
            };
    }
}
