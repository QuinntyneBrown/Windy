using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Windy.Shared.Dtos;

namespace Windy.FunctionsApp.Orchestrators
{
    [StorageAccount("AzureWebJobsStorage")]
    public class OrderOrchestrator
    {
        [FunctionName("O_SaveOrder")]
        public static async Task<object> SaveOrder(
            [OrchestrationTrigger] IDurableOrchestrationContext context
            )
        {
            return await Task.FromResult<object>(new { });
        }

        [FunctionName("S_SaveOrder")]
        public static async Task<string> SaveOrder(
            [ActivityTrigger] SaveOrderDto request,
            ILogger log)
        {

            return await Task.FromResult("");
        }
    }
}
