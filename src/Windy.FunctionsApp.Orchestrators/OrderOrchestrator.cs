using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Windy.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Windy.FunctionsApp.Orchestrators
{
    [StorageAccount("AzureWebJobsStorage")]
    public class OrderOrchestrator
    {
        [FunctionName("O_SaveOrder")]
        public static async Task<object> SaveOrder(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger log

            )
        {
            SaveOrderDto dto = context.GetInput<SaveOrderDto>();

            if (!context.IsReplaying)
                log.LogInformation($"Save Order {dto} starting.....");

            dto = await context.CallActivityAsync<SaveOrderDto>("A_SaveOrder", dto);

            return await Task.FromResult<object>(new { });
        }

        [FunctionName("A_SaveOrder")]
        public static async Task<string> SaveOrder(
            [ActivityTrigger] SaveOrderDto request,
            ILogger log)
        {

            return await Task.FromResult("");
        }
    }
}
