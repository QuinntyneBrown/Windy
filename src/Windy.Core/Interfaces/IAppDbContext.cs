using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Windy.Core.Entities;

namespace Windy.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Company> Companies { get;}
        DbSet<Customer> Customers { get; }
        DbSet<Employee> Employees { get;}
        DbSet<AssignedWorkOrder> AssignedWorkOrders { get;}
        DbSet<AssignedWorkOrderStatus> AssignedWorkOrderStatuses { get;}
        DbSet<JobTitle> JobTitles { get;}
        DbSet<Role> Roles { get;}
        DbSet<User> Users { get;}
        DbSet<WorkOrder> WorkOrders { get;}
        DbSet<WorkOrderStatus> WorkOrderStatuses { get;}
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
