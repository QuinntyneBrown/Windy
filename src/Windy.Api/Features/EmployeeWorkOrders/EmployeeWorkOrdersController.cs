using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.EmployeeWorkOrders
{
    [Authorize]
    [ApiController]
    [Route("api/employeeWorkOrders")]
    public class EmployeeWorkOrdersController
    {
        private readonly IMediator _meditator;

        public EmployeeWorkOrdersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeeWorkOrdersQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeeWorkOrdersQuery.Response>> Get()
            => await _meditator.Send(new GetEmployeeWorkOrdersQuery.Request());

        [HttpGet("{employeeWorkOrderId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeeWorkOrderByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeeWorkOrderByIdQuery.Response>> GetById(GetEmployeeWorkOrderByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertEmployeeWorkOrderCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertEmployeeWorkOrderCommand.Response>> Upsert(UpsertEmployeeWorkOrderCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveEmployeeWorkOrderCommand.Request request)
            => await _meditator.Send(request);
    }
}
