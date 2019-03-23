using Windy.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedWorkOrders
{
    public class RemoveAssignedWorkOrderCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.AssignedWorkOrderId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid AssignedWorkOrderId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var AssignedWorkOrder = await _context.AssignedWorkOrders.FindAsync(request.AssignedWorkOrderId);

                _context.AssignedWorkOrders.Remove(AssignedWorkOrder);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
