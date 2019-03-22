using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.WorkOrders
{
    [Authorize]
    [ApiController]
    [Route("api/workOrders")]
    public class WorkOrdersController
    {
        private readonly IMediator _meditator;

        public WorkOrdersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetWorkOrdersQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetWorkOrdersQuery.Response>> Get()
            => await _meditator.Send(new GetWorkOrdersQuery.Request());

        [HttpGet("{workOrderId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetWorkOrderByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetWorkOrderByIdQuery.Response>> GetById(GetWorkOrderByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertWorkOrderCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertWorkOrderCommand.Response>> Upsert(UpsertWorkOrderCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveWorkOrderCommand.Request request)
            => await _meditator.Send(request);
    }
}
