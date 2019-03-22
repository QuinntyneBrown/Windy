using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.Companies
{
    public class CompanyDto
    {        
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
    }

    public static class CompanyExtensions
    {        
        public static CompanyDto ToDto(this Company company)
            => new CompanyDto
            {
                CompanyId = company.CompanyId,
                Name = company.Name
            };
    }
}
