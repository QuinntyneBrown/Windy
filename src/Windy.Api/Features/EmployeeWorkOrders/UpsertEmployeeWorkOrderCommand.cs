using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.EmployeeWorkOrders
{
    public class UpsertEmployeeWorkOrderCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.EmployeeWorkOrder.EmployeeWorkOrderId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public EmployeeWorkOrderDto EmployeeWorkOrder { get; set; }
        }

        public class Response
        {
            public Guid EmployeeWorkOrderId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var employeeWorkOrder = await _context.EmployeeWorkOrders.FindAsync(request.EmployeeWorkOrder.EmployeeWorkOrderId);

                if (employeeWorkOrder == null) {
                    employeeWorkOrder = new EmployeeWorkOrder();
                    _context.EmployeeWorkOrders.Add(employeeWorkOrder);
                }



                await _context.SaveChangesAsync(cancellationToken);

                //fix
                return new Response() { EmployeeWorkOrderId = employeeWorkOrder.EmployeeId };
            }
        }
    }
}
