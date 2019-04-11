using Windy.Shared.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Security.Claims;

namespace Windy.FunctionApp.SignalR
{
    public static class Functions
    {
        [FunctionName("GetSignalRInfo")]
        public static IActionResult GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="signalrInfo/{hubName}")] HttpRequest req,   
            string hubName,
            IBinder binder,
            [AccessToken] ClaimsPrincipal principal
            )
        {
            if (!principal.Identity.IsAuthenticated) return new UnauthorizedResult();

            var info = binder.Bind<SignalRConnectionInfo>(new SignalRConnectionInfoAttribute
            {
                HubName = hubName,
                UserId = principal.Identity.Name
            });

            return new OkObjectResult(info);
        }
    }
}
