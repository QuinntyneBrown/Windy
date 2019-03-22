using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Windy.Api.Features.Companies
{
    [Authorize]
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController
    {
        private readonly IMediator _meditator;

        public CompaniesController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompaniesQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompaniesQuery.Response>> Get()
            => await _meditator.Send(new GetCompaniesQuery.Request());

        [HttpGet("{companyId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompanyByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompanyByIdQuery.Response>> GetById(GetCompanyByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertCompanyCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertCompanyCommand.Response>> Upsert(UpsertCompanyCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveCompanyCommand.Request request)
            => await _meditator.Send(request);
    }
}
