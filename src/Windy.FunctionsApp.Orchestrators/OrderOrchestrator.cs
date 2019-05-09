using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

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
    }
}
