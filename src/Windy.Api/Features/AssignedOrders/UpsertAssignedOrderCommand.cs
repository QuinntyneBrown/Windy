using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedOrders
{
    public class UpsertAssignedOrderCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.AssignedOrder.AssignedOrderId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public AssignedOrderDto AssignedOrder { get; set; }
        }

        public class Response
        {
            public Guid AssignedOrderId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var assignedOrder = await _context.AssignedOrders.FindAsync(request.AssignedOrder.AssignedOrderId);

                if (assignedOrder == null) {
                    assignedOrder = new AssignedOrder();
                    _context.AssignedOrders.Add(assignedOrder);
                }


                await _context.SaveChangesAsync(cancellationToken);

                return new Response() {  };
            }
        }
    }
}
