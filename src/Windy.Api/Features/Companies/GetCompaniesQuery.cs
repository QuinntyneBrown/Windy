using Windy.Core.Interfaces;
using Windy.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Companies
{
    public class GetCompaniesQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<CompanyDto> Companies { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                =>  new Response()
                {
                    Companies = await _context.Companies.Select(x => x.ToDto()).ToArrayAsync()
                };
        }
    }
}
