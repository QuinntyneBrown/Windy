using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.WorkOrders
{
    public class GetWorkOrderByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid WorkOrderId { get; set; }
        }

        public class Response
        {
            public WorkOrderDto WorkOrder { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    WorkOrder = (await _context.WorkOrders.FindAsync(request.WorkOrderId)).ToDto()
                };
        }
    }
}
