using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.AssignedOrders
{
    public class AssignedOrderDto
    {        
        public Guid AssignedOrderId { get; set; }
        public string Name { get; set; }
    }

    public static class AssignedOrderExtensions
    {        
        public static AssignedOrderDto ToDto(this AssignedOrder assignedOrder)
            => new AssignedOrderDto
            {

            };
    }
}
