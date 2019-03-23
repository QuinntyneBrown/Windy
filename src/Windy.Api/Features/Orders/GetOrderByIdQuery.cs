using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Orders
{
    public class GetOrderByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid OrderId { get; set; }
        }

        public class Response
        {
            public OrderDto Order { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    Order = (await _context.Orders.FindAsync(request.OrderId)).ToDto()
                };
        }
    }
}
