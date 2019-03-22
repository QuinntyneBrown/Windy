using Windy.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.EmployeeWorkOrders
{
    public class RemoveEmployeeWorkOrderCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.EmployeeWorkOrderId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid EmployeeWorkOrderId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var employeeWorkOrder = await _context.EmployeeWorkOrders.FindAsync(request.EmployeeWorkOrderId);

                _context.EmployeeWorkOrders.Remove(employeeWorkOrder);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
