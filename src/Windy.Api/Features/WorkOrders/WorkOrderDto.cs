using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.WorkOrders
{
    public class WorkOrderDto
    {
        public Guid CompanyId { get; set; }
        public Guid WorkOrderId { get; set; }
        public Guid CustomerId { get; set; }
    }

    public static class WorkOrderExtensions
    {        
        public static WorkOrderDto ToDto(this WorkOrder workOrder)
            => new WorkOrderDto
            {
                WorkOrderId = workOrder.WorkOrderId                
            };
    }
}
