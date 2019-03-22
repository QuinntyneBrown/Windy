using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Companies
{
    public class GetCompanyByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid CompanyId { get; set; }
        }

        public class Response
        {
            public CompanyDto Company { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    Company = (await _context.Companies.FindAsync(request.CompanyId)).ToDto()
                };
        }
    }
}
