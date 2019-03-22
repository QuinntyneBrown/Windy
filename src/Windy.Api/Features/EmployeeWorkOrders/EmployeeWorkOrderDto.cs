using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.EmployeeWorkOrders
{
    public class EmployeeWorkOrderDto
    {        
        public Guid EmployeeWorkOrderId { get; set; }
        public string Name { get; set; }
    }

    public static class EmployeeWorkOrderExtensions
    {        
        public static EmployeeWorkOrderDto ToDto(this EmployeeWorkOrder employeeWorkOrder)
            => new EmployeeWorkOrderDto
            {

            };
    }
}
