using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.WorkOrders
{
    public class UpsertWorkOrderCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.WorkOrder.WorkOrderId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public WorkOrderDto WorkOrder { get; set; }
        }

        public class Response
        {
            public Guid WorkOrderId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var workOrder = await _context.WorkOrders.FindAsync(request.WorkOrder.WorkOrderId);

                if (workOrder == null) {
                    workOrder = new WorkOrder();
                    _context.WorkOrders.Add(workOrder);
                }

                workOrder.Name = request.WorkOrder.Name;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { WorkOrderId = workOrder.WorkOrderId };
            }
        }
    }
}
