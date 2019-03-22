using Windy.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Employees
{
    public class RemoveEmployeeCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.EmployeeId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid EmployeeId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FindAsync(request.EmployeeId);

                _context.Employees.Remove(employee);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
