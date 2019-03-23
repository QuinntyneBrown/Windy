using Windy.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedOrders
{
    public class RemoveAssignedOrderCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.AssignedOrderId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid AssignedOrderId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var assignedOrder = await _context.AssignedOrders.FindAsync(request.AssignedOrderId);

                _context.AssignedOrders.Remove(assignedOrder);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
