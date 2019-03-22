using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.Employees
{
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController
    {
        private readonly IMediator _meditator;

        public EmployeesController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeesQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeesQuery.Response>> Get()
            => await _meditator.Send(new GetEmployeesQuery.Request());

        [HttpGet("{employeeId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeeByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeeByIdQuery.Response>> GetById(GetEmployeeByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertEmployeeCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertEmployeeCommand.Response>> Upsert(UpsertEmployeeCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveEmployeeCommand.Request request)
            => await _meditator.Send(request);
    }
}
