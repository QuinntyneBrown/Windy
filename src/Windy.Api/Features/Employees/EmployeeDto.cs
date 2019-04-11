using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.Employees
{
    public class EmployeeDto
    {
        public Guid? CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
    }

    public static class EmployeeExtensions
    {        
        public static EmployeeDto ToDto(this Employee employee)
            => new EmployeeDto
            {
                EmployeeId = employee.EmployeeId
            };
    }
}
