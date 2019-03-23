using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedWorkOrders
{
    public class GetAssignedWorkOrderByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid AssignedWorkOrderId { get; set; }
        }

        public class Response
        {
            public AssignedWorkOrderDto AssignedWorkOrder { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    AssignedWorkOrder = (await _context.AssignedWorkOrders.FindAsync(request.AssignedWorkOrderId)).ToDto()
                };
        }
    }
}
