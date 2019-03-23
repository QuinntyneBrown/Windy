using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.Orders
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrdersController
    {
        private readonly IMediator _meditator;

        public OrdersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrdersQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrdersQuery.Response>> Get()
            => await _meditator.Send(new GetOrdersQuery.Request());

        [HttpGet("{orderId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrderByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrderByIdQuery.Response>> GetById(GetOrderByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertOrderCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertOrderCommand.Response>> Upsert(UpsertOrderCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveOrderCommand.Request request)
            => await _meditator.Send(request);
    }
}
