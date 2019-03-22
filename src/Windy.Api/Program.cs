using Windy.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Windy.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            ProcessDbCommands(args, host);

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void ProcessDbCommands(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (args.Contains("dropdb"))
                    context.Database.EnsureDeleted();

                if (args.Contains("seeddb"))
                {
                    // add job titles
                    //  - Manager
                    //  - Technician

                    // add Employee Work Order Statues
                    //  - Incomplete
                    //  - Complete

                    // add Work Order Status
                    //  - New
                    //  - Completed
                }

                if (args.Contains("createdb"))
                    context.Database.EnsureCreated();

                if (args.Contains("createdb") || args.Contains("seeddb") || args.Contains("dropdb"))
                    Environment.Exit(0);
            }
        }
    }
}