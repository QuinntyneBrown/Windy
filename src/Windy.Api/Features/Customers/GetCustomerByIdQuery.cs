using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Customers
{
    public class GetCustomerByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid CustomerId { get; set; }
        }

        public class Response
        {
            public CustomerDto Customer { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    Customer = (await _context.Customers.FindAsync(request.CustomerId)).ToDto()
                };
        }
    }
}
