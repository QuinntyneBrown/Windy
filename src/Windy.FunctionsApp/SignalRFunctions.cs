using Windy.Shared.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Windy.Shared;

namespace Windy.FunctionApp
{
    public static class SignalRFunctions
    {
        [FunctionName("GetSignalRInfo")]
        public static IActionResult GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="signalrInfo/{hubName}")] HttpRequest req,   
            string hubName,
            IBinder binder,
            ILogger log
            )
        {
            try
            {
                var principal = AuthorizationUtilities.ResolveClaimsPrincipal(req);

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

        [FunctionName("sendNotification")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Post", Route = "sendNotification/{userId}")]
            object message,
            string userId,
            [SignalR(HubName = "notificationsHub")]IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            try
            {
                return signalRMessages.AddAsync(
                    new SignalRMessage
                    {
                        UserId = userId,
                        Target = "sendNotification",
                        Arguments = new[] { message }
                    });
            }
            finally
            {
                log.LogError("Sned Notification Error");
            }
        }
    }
}
