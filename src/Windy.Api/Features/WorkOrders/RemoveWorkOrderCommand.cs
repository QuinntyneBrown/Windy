using Windy.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.WorkOrders
{
    public class RemoveWorkOrderCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.WorkOrderId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid WorkOrderId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var workOrder = await _context.WorkOrders.FindAsync(request.WorkOrderId);

                _context.WorkOrders.Remove(workOrder);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
