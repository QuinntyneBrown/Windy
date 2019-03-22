using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.EmployeeWorkOrders
{
    public class GetEmployeeWorkOrderByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid EmployeeWorkOrderId { get; set; }
        }

        public class Response
        {
            public EmployeeWorkOrderDto EmployeeWorkOrder { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    EmployeeWorkOrder = (await _context.EmployeeWorkOrders.FindAsync(request.EmployeeWorkOrderId)).ToDto()
                };
        }
    }
}
