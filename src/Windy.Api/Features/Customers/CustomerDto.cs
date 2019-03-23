using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.Customers
{
    public class CustomerDto
    {        
        public Guid CustomerId { get; set; }        
    }

    public static class CustomerExtensions
    {        
        public static CustomerDto ToDto(this Customer customer)
            => new CustomerDto
            {
                CustomerId = customer.CustomerId,                
            };
    }
}
