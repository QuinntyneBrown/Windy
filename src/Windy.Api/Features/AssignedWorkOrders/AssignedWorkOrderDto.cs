using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.AssignedWorkOrders
{
    public class AssignedWorkOrderDto
    {        
        public Guid AssignedWorkOrderId { get; set; }
        public string Name { get; set; }
    }

    public static class AssignedWorkOrderExtensions
    {        
        public static AssignedWorkOrderDto ToDto(this AssignedWorkOrder AssignedWorkOrder)
            => new AssignedWorkOrderDto
            {

            };
    }
}
