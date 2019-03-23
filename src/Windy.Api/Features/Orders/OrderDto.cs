using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.Orders
{
    public class OrderDto
    {        
        public Guid OrderId { get; set; }
        public string Name { get; set; }
    }

    public static class OrderExtensions
    {        
        public static OrderDto ToDto(this Order order)
            => new OrderDto
            {
                OrderId = order.OrderId                
            };
    }
}
