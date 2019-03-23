using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedWorkOrders
{
    public class UpsertAssignedWorkOrderCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.AssignedWorkOrder.AssignedWorkOrderId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public AssignedWorkOrderDto AssignedWorkOrder { get; set; }
        }

        public class Response
        {
            public Guid AssignedWorkOrderId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var AssignedWorkOrder = await _context.AssignedWorkOrders.FindAsync(request.AssignedWorkOrder.AssignedWorkOrderId);

                if (AssignedWorkOrder == null) {
                    AssignedWorkOrder = new AssignedWorkOrder();
                    _context.AssignedWorkOrders.Add(AssignedWorkOrder);
                }



                await _context.SaveChangesAsync(cancellationToken);

                //fix
                return new Response() { AssignedWorkOrderId = AssignedWorkOrder.EmployeeId };
            }
        }
    }
}
