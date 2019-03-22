using Windy.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Employees
{
    public class GetEmployeeByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid EmployeeId { get; set; }
        }

        public class Response
        {
            public EmployeeDto Employee { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    Employee = (await _context.Employees.FindAsync(request.EmployeeId)).ToDto()
                };
        }
    }
}
