using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Companies
{
    public class UpsertCompanyCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.Company.CompanyId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public CompanyDto Company { get; set; }
        }

        public class Response
        {
            public Guid CompanyId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var company = await _context.Companies.FindAsync(request.Company.CompanyId);

                if (company == null) {
                    company = new Company();
                    _context.Companies.Add(company);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { CompanyId = company.CompanyId };
            }
        }
    }
}
