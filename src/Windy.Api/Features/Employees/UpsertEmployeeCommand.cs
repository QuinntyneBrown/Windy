using Windy.Core.Interfaces;
using Windy.Core.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Windy.Api.Features.Employees
{
    public class UpsertEmployeeCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.Employee.EmployeeId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public EmployeeDto Employee { get; set; }
        }

        public class Response
        {
            public Guid EmployeeId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var employee = await _context.Employees.FindAsync(request.Employee.EmployeeId);

                if (employee == null) {
                    employee = new Employee();
                    _context.Employees.Add(employee);
                }


                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { EmployeeId = employee.EmployeeId };
            }
        }
    }
}
