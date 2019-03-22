using Windy.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Companies
{
    public class RemoveCompanyCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CompanyId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid CompanyId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var company = await _context.Companies.FindAsync(request.CompanyId);

                _context.Companies.Remove(company);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
