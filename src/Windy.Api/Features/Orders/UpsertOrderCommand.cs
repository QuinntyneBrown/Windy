using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Orders
{
    public class UpsertOrderCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.Order.OrderId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public OrderDto Order { get; set; }
        }

        public class Response
        {
            public Guid OrderId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var order = await _context.Orders.FindAsync(request.Order.OrderId);

                if (order == null) {
                    order = new Order();
                    _context.Orders.Add(order);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { OrderId = order.OrderId };
            }
        }
    }
}
