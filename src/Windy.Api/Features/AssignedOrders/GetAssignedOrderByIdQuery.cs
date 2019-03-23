using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedOrders
{
    public class GetAssignedOrderByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid AssignedOrderId { get; set; }
        }

        public class Response
        {
            public AssignedOrderDto AssignedOrder { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    AssignedOrder = (await _context.AssignedOrders.FindAsync(request.AssignedOrderId)).ToDto()
                };
        }
    }
}
