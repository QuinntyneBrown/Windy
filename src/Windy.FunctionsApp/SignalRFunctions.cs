using Windy.Shared.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System;

namespace Windy.FunctionApp
{
    public static class SignalRFunctions
    {
        [FunctionName("GetSignalRInfo")]
        public static IActionResult GetSignalRInfo(
            [AccessToken] ClaimsPrincipal principal,
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="signalrInfo/{hubName}")] HttpRequest req,   
            string hubName,
            IBinder binder,
            ILogger log
            )
        {
            try
            {
                if (!principal.Identity.IsAuthenticated) return new UnauthorizedResult();

                var info = binder.Bind<SignalRConnectionInfo>(new SignalRConnectionInfoAttribute
                {
                    HubName = hubName,
                    UserId = principal.Identity.Name
                });

                return new OkObjectResult(info);
            }
            catch(Exception e)
            {
                var error = $"GetSignalRInfo failed: {e.Message}";

                log.LogError(error);

                return new BadRequestObjectResult(error);
            }
        }
    }
}
