using Windy.Core.Interfaces;
using Windy.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedOrders
{
    public class GetAssignedOrdersQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<AssignedOrderDto> AssignedOrders { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                =>  new Response()
                {
                    AssignedOrders = await _context.AssignedOrders.Select(x => x.ToDto()).ToArrayAsync()
                };
        }
    }
}
