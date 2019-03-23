using Windy.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Windy.Core.Entities;
using Microsoft.Extensions.Configuration;
using Windy.Core.Identity;

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
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                if (args.Contains("dropdb"))
                    context.Database.EnsureDeleted();

                if (args.Contains("seeddb"))
                {

                    var managerRole = context.Roles.SingleOrDefault(x => x.Name == "Manager");

                    if (managerRole == null)
                        context.Roles.Add(new Role { Name = "Manager" });

                    var technicianRole = context.Roles.SingleOrDefault(x => x.Name == "Technician");

                    if (technicianRole == null)
                        context.Roles.Add(new Role { Name = "Technician" });

                    var systemRole = context.Roles.SingleOrDefault(x => x.Name == "System");

                    if (systemRole == null)
                        context.Roles.Add(new Role { Name = "System" });

                    var managerJobTitle = context.JobTitles.SingleOrDefault(x => x.Name == "Manager");

                    if (managerJobTitle == null)
                        context.JobTitles.Add(new JobTitle { Name = "Manager" });

                    var technicianJobTitle = context.JobTitles.SingleOrDefault(x => x.Name == "Technician");

                    if (technicianJobTitle == null)
                        context.JobTitles.Add(new JobTitle { Name = "Technician" });

                    var workOrderIncompleteStatus = context.WorkOrderStatuses.SingleOrDefault(x => x.Name == "Incomplete");

                    if (workOrderIncompleteStatus == null)
                        context.WorkOrderStatuses.Add(new WorkOrderStatus { Name = "Incomplete" });

                    var workOrderCompleteStatus = context.WorkOrderStatuses.SingleOrDefault(x => x.Name == "Complete");

                    if (workOrderCompleteStatus == null)
                        context.WorkOrderStatuses.Add(new WorkOrderStatus { Name = "Complete" });

                    var AssignedWorkOrderIncompleteStatus = context.AssignedWorkOrderStatuses.SingleOrDefault(x => x.Name == "Incomplete");

                    if (AssignedWorkOrderIncompleteStatus == null)
                        context.AssignedWorkOrderStatuses.Add(new AssignedWorkOrderStatus { Name = "Incomplete" });

                    var AssignedWorkOrderCompleteStatus = context.WorkOrderStatuses.SingleOrDefault(x => x.Name == "Complete");

                    if (AssignedWorkOrderCompleteStatus == null)
                        context.AssignedWorkOrderStatuses.Add(new AssignedWorkOrderStatus { Name = "Complete" });

                    User user = default;

                    if (context.Users.SingleOrDefault(x => x.Username == configuration["Seed:DefaultUser:Username"]) == null)
                    {
                        user = new User()
                        {
                            CompanyId = new Guid(configuration["Seed:DefaultUser:CompanyId"]),
                            Username = configuration["Seed:DefaultUser:Username"]
                        };

                        user.Password = new PasswordHasher().HashPassword(user.Salt, configuration["Seed:DefaultUser:Password"]);

                        user.UserRoles.Add(new UserRole {
                            Role = context.Roles.Single(x => x.Name == "System")
                        });

                        context.Users.Add(user);

                    }
                    context.SaveChanges();
                }

                if (args.Contains("createdb"))
                    context.Database.EnsureCreated();

                if (args.Contains("createdb") || args.Contains("seeddb") || args.Contains("dropdb"))
                    Environment.Exit(0);
            }
        }
    }
}