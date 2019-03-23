using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.AssignedOrders
{
    [Authorize]
    [ApiController]
    [Route("api/assignedOrders")]
    public class AssignedOrdersController
    {
        private readonly IMediator _meditator;

        public AssignedOrdersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAssignedOrdersQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAssignedOrdersQuery.Response>> Get()
            => await _meditator.Send(new GetAssignedOrdersQuery.Request());

        [HttpGet("{assignedOrderId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetAssignedOrderByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetAssignedOrderByIdQuery.Response>> GetById(GetAssignedOrderByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertAssignedOrderCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertAssignedOrderCommand.Response>> Upsert(UpsertAssignedOrderCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveAssignedOrderCommand.Request request)
            => await _meditator.Send(request);
    }
}
