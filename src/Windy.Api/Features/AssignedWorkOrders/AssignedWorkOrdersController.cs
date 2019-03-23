using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedWorkOrders
{
    [Authorize]
    [ApiController]
    [Route("api/AssignedWorkOrders")]
    public class AssignedWorkOrdersController
    {
        private readonly IMediator _meditator;

        public AssignedWorkOrdersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAssignedWorkOrdersQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAssignedWorkOrdersQuery.Response>> Get()
            => await _meditator.Send(new GetAssignedWorkOrdersQuery.Request());

        [HttpGet("{AssignedWorkOrderId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAssignedWorkOrderByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAssignedWorkOrderByIdQuery.Response>> GetById(GetAssignedWorkOrderByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertAssignedWorkOrderCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertAssignedWorkOrderCommand.Response>> Upsert(UpsertAssignedWorkOrderCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveAssignedWorkOrderCommand.Request request)
            => await _meditator.Send(request);
    }
}
